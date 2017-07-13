CREATE TABLE public.products (
	id uuid NOT NULL,
	brand_id uuid NOT NULL,
	code varchar(200) NOT NULL,
	"name" varchar(200) NOT NULL,
	stock numeric NOT NULL,
	unit_price money NOT NULL,
	vat money NOT NULL,
	created date NULL,
	update_time date NULL,
	short_description varchar(500) NULL,
	long_description varchar(1500) NULL,
	CONSTRAINT products_pk PRIMARY KEY (id)
)
WITH (
	OIDS=FALSE
) ;


CREATE TABLE public.product_properties (
	id uuid NOT NULL,
	product_id uuid NOT NULL,
	"key" varchar(200) NOT NULL,
	value varchar(1200) NOT NULL,
	CONSTRAINT product_properties_pk PRIMARY KEY (id),
	CONSTRAINT product_properties_products_fk FOREIGN KEY (product_id) REFERENCES public.products(id)
)
WITH (
	OIDS=FALSE
) ;
CREATE INDEX product_properties_product_id_idx ON public.product_properties (product_id DESC,id DESC,"key" DESC) ;



CREATE TABLE public.option_groups (
	id uuid NOT NULL,
	"name" varchar(200) NOT NULL,
	CONSTRAINT option_groups_pk PRIMARY KEY (id)
)
WITH (
	OIDS=FALSE
) ;
CREATE INDEX option_groups_id_idx ON public.option_groups (id DESC) ;


CREATE TABLE public."options" (
	id uuid NOT NULL,
	"name" varchar(200) NOT NULL,
	CONSTRAINT options_pk PRIMARY KEY (id)
)
WITH (
	OIDS=FALSE
) ;
CREATE INDEX options_id_idx ON public."options" (id DESC) ;


CREATE TABLE public.product_options (
	id uuid NOT NULL,
	product_id uuid NOT NULL,
	option_group_id uuid NOT NULL,
	option_id uuid NOT NULL,
	price money NULL,
	CONSTRAINT product_options_pk PRIMARY KEY (id),
	CONSTRAINT product_options_options_fk FOREIGN KEY (option_id) REFERENCES public."options"(id)
)
WITH (
	OIDS=FALSE
) ;
CREATE INDEX product_options_id_idx ON public.product_options (id DESC,product_id DESC,option_group_id DESC,option_id DESC) ;