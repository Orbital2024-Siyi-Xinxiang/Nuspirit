--
-- PostgreSQL database dump
--

-- Dumped from database version 16.3 (Postgres.app)
-- Dumped by pg_dump version 16.3 (Postgres.app)

SET statement_timeout = 0;
SET lock_timeout = 0;
SET idle_in_transaction_session_timeout = 0;
SET client_encoding = 'UTF8';
SET standard_conforming_strings = on;
SELECT pg_catalog.set_config('search_path', '', false);
SET check_function_bodies = false;
SET xmloption = content;
SET client_min_messages = warning;
SET row_security = off;

SET default_tablespace = '';

SET default_table_access_method = heap;

--
-- Name: users; Type: TABLE; Schema: public; Owner: emma
--
--
-- Name: user_location; Type: TABLE; Schema: public; Owner: emma
--
CREATE TABLE public.user_location (
    user_id integer NOT NULL,
    latitude numeric(10, 6) NOT NULL,
    longitude numeric(10, 6) NOT NULL,
    last_updated timestamp without time zone DEFAULT CURRENT_TIMESTAMP
);

ALTER TABLE public.user_location OWNER TO emma;

--
-- Name: user_wallet; Type: TABLE; Schema: public; Owner: emma
--
CREATE TABLE public.user_wallet (
    user_id integer NOT NULL,
    balance numeric(10, 2) NOT NULL,
    last_updated timestamp without time zone DEFAULT CURRENT_TIMESTAMP
);
ALTER TABLE public.user_wallet OWNER TO emma;

--
-- Name: user_assets; Type: TABLE; Schema: public; Owner: emma
--
CREATE TABLE public.user_assets (
    user_id integer NOT NULL,
    asset_name character varying(50) NOT NULL,
    quantity integer NOT NULL,
    last_updated timestamp without time zone DEFAULT CURRENT_TIMESTAMP
);
ALTER TABLE public.user_assets OWNER TO emma;

CREATE TABLE public.users (
    user_id integer NOT NULL,
    username character varying(50) NOT NULL,
    password character varying(255) NOT NULL,
    email character varying(100) NOT NULL,
    creation_date timestamp without time zone DEFAULT CURRENT_TIMESTAMP
);


ALTER TABLE public.users OWNER TO emma;

--
-- Name: users_user_id_seq; Type: SEQUENCE; Schema: public; Owner: emma
--

CREATE SEQUENCE public.users_user_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE public.users_user_id_seq OWNED BY NONE;

--
-- Name: users_user_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: emma
--

ALTER SEQUENCE public.users_user_id_seq OWNED BY public.users.user_id;


--
-- Name: users user_id; Type: DEFAULT; Schema: public; Owner: emma
--

ALTER TABLE ONLY public.users ALTER COLUMN user_id SET DEFAULT nextval('public.users_user_id_seq'::regclass);


--
-- Data for Name: users; Type: TABLE DATA; Schema: public; Owner: emma
--

COPY public.users (user_id, username, password, email, creation_date) FROM stdin;
3	newuser	$2a$08$h/jlb5dsGV.suRhYovVcX.hbnSLP.GdRL9SBBa3LcQcXvkhNGu6de	user@example.com	2024-05-12 22:28:58.543805
1	Testuser0	Q	test0@email.com	2024-05-12 18:49:05.929766
6	Test3	$2a$08$XAgNzBsCd2gb5eXvEXY7L.G3onT2qM.OdZUwCUsEIL3IkFU0Za48W	Test3@gmail.om	2024-05-12 22:52:53.483862
7	Test4	$2a$08$2GfI05xDchQCZDWuXt54/..tLR62X6qY40vBiOxeBVeaU7IooJc2C	Test4@gmail.com	2024-05-12 23:21:01.749132
8	Test5	$2a$08$1IFq1OphrMnSSXG37O6AGOj7B3KP.Fs71y/gyk20D/cohN.HD.tdO	Test5.gmail.com	2024-05-12 23:27:07.546001
9	Test6	$2a$08$8kUYAD.aj4BwRNhzgcw2/.XTl1OjGonIcE9CzLww1jDom4vGqypDG	test6@gmail.com	2024-05-12 23:45:50.53344
\.


--
-- Name: users_user_id_seq; Type: SEQUENCE SET; Schema: public; Owner: emma
--

SELECT pg_catalog.setval('public.users_user_id_seq', 9, true);


--
-- Name: users users_email_key; Type: CONSTRAINT; Schema: public; Owner: emma
--

ALTER TABLE ONLY public.users
    ADD CONSTRAINT users_email_key UNIQUE (email);


--
-- Name: users users_pkey; Type: CONSTRAINT; Schema: public; Owner: emma
--

ALTER TABLE ONLY public.users
    ADD CONSTRAINT users_pkey PRIMARY KEY (user_id);


--
-- Name: users users_username_key; Type: CONSTRAINT; Schema: public; Owner: emma
--

ALTER TABLE ONLY public.users
    ADD CONSTRAINT users_username_key UNIQUE (username);


--
-- PostgreSQL database dump complete
--
