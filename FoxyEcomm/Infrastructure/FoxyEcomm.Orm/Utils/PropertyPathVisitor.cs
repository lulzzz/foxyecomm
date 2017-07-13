using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace FoxyEcomm.Orm.Utils
{
    public class PropertyPathVisitor : ExpressionVisitor
    {
        private Stack<MemberInfo> _stack;

        public MemberInfo GetPropertyPath(Expression expression)
        {
            _stack = new Stack<MemberInfo>();
            Visit(expression);
            return _stack.LastOrDefault();
        }

        protected override Expression VisitMember(MemberExpression expression)
        {
            _stack?.Push(expression.Member);
            return base.VisitMember(expression);
        }

        protected override Expression VisitMethodCall(MethodCallExpression expression)
        {
            if (!IsLinqOperator(expression.Method))
                return base.VisitMethodCall(expression);

            for (var i = expression.Arguments.Count - 1; i >= 0; i--)
                Visit(expression.Arguments[i]);

            return expression;
        }

        private static bool IsLinqOperator(MemberInfo method)
        {
            if (method.DeclaringType != typeof(Enumerable))
                return false;

            return method.GetCustomAttribute<ExtensionAttribute>() != null;
        }
    }
}