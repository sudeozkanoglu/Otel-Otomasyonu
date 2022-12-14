PGDMP     9                     z            proje    15.0    15.0 ?    ?           0    0    ENCODING    ENCODING        SET client_encoding = 'UTF8';
                      false            ?           0    0 
   STDSTRINGS 
   STDSTRINGS     (   SET standard_conforming_strings = 'on';
                      false            ?           0    0 
   SEARCHPATH 
   SEARCHPATH     8   SELECT pg_catalog.set_config('search_path', '', false);
                      false            ?           1262    16609    proje    DATABASE     y   CREATE DATABASE proje WITH TEMPLATE = template0 ENCODING = 'UTF8' LOCALE_PROVIDER = libc LOCALE = 'Turkish_Turkey.1254';
    DROP DATABASE proje;
                postgres    false            ?            1255    25030    gelirtoplamı() 	   PROCEDURE     /  CREATE PROCEDURE public."gelirtoplamı"()
    LANGUAGE plpgsql
    AS $$
declare 
gelirrow gelir%ROWTYPE; 
toplam bigint;
begin 
	for gelirrow in select * from gelir
		loop 
			toplam:=(select sum("gelirTutar") from gelir);
		end loop;
	insert into "toplamGelir"("totalGelir") values (toplam);
end;
$$;
 )   DROP PROCEDURE public."gelirtoplamı"();
       public          postgres    false            ?            1255    25034    gidertoplamı() 	   PROCEDURE     /  CREATE PROCEDURE public."gidertoplamı"()
    LANGUAGE plpgsql
    AS $$
declare 
giderrow gider%ROWTYPE; 
toplam bigint;
begin 
	for giderrow in select * from gider
		loop 
			toplam:=(select sum("giderTutar") from gider);
		end loop;
	insert into "toplamGider"("totalGider") values (toplam);
end;
$$;
 )   DROP PROCEDURE public."gidertoplamı"();
       public          postgres    false            ?            1255    25029 &   indirimtutarıyenile(numeric, numeric) 	   PROCEDURE       CREATE PROCEDURE public."indirimtutarıyenile"(IN yenipersonelindirim numeric, IN yenidevamliindirim numeric)
    LANGUAGE plpgsql
    AS $$
begin
	update indirim set "personelIndirim" = yeniPersonelIndirim;
	update indirim set "devamliIndirim" = yeniDevamliIndirim;
end;
$$;
 m   DROP PROCEDURE public."indirimtutarıyenile"(IN yenipersonelindirim numeric, IN yenidevamliindirim numeric);
       public          postgres    false            ?            1255    25037    kontrolkontenjan()    FUNCTION     ?   CREATE FUNCTION public.kontrolkontenjan() RETURNS trigger
    LANGUAGE plpgsql
    AS $$
begin 
	if new."etkinlikKontenjan" > 200 then
		raise exception 'Kontenjan Sınırını Aştınız';
end if;
return new;
end;
$$;
 )   DROP FUNCTION public.kontrolkontenjan();
       public          postgres    false            ?            1255    25013    musterisicilnokontrol()    FUNCTION     ?   CREATE FUNCTION public.musterisicilnokontrol() RETURNS trigger
    LANGUAGE plpgsql
    AS $$
begin
	if length(new."sicilNo") > 10 then 
		raise exception 'Sicil No 10 Haneden Fazla Olamaz !' ;
	end if;
return new;
end;
$$;
 .   DROP FUNCTION public.musterisicilnokontrol();
       public          postgres    false            ?            1255    25022    odasayisi()    FUNCTION     ?   CREATE FUNCTION public.odasayisi() RETURNS trigger
    LANGUAGE plpgsql
    AS $$
declare toplamOda int;
begin
toplamOda:=(select count(*) from "oda");
	if toplamOda > 20 then
		raise exception 'Daha fazla oda eklenemez !';
	end if;
return new;
end;
$$;
 "   DROP FUNCTION public.odasayisi();
       public          postgres    false            ?            1255    25028 '   otelsahibidegistirme(character varying) 	   PROCEDURE     ?   CREATE PROCEDURE public.otelsahibidegistirme(IN yeni character varying)
    LANGUAGE plpgsql
    AS $$
begin
	update otel set "otelSahibi" = yeni;
end;
$$;
 G   DROP PROCEDURE public.otelsahibidegistirme(IN yeni character varying);
       public          postgres    false            ?            1255    25011    personelsicilnokontrol()    FUNCTION     ?   CREATE FUNCTION public.personelsicilnokontrol() RETURNS trigger
    LANGUAGE plpgsql
    AS $$
begin
	if length(new."perYakSicilNo") > 10 then 
		raise exception 'Sicil No 10 Haneden Fazla Olamaz !' ;
	end if;
return new;
end;
$$;
 /   DROP FUNCTION public.personelsicilnokontrol();
       public          postgres    false            ?            1255    25035    telefonno()    FUNCTION     ?   CREATE FUNCTION public.telefonno() RETURNS trigger
    LANGUAGE plpgsql
    AS $$
begin
	if length(new."telefonNo") > 11 then 
		raise exception 'Telefon Numarası 10 Haneden Fazla Olamaz !' ;
	end if;
return new;
end;
$$;
 "   DROP FUNCTION public.telefonno();
       public          postgres    false            ?            1259    16644    calisan    TABLE     ?  CREATE TABLE public.calisan (
    "calisanNo" integer NOT NULL,
    "calisanAd" character varying(45) NOT NULL,
    "calisanSoyad" character varying(45) NOT NULL,
    "dogumTarihi" date NOT NULL,
    "medeniHal" character varying NOT NULL,
    cinsiyet character varying NOT NULL,
    "calisanTür" character varying NOT NULL,
    "iseGiris" date NOT NULL,
    departman character varying NOT NULL,
    "otelID" integer NOT NULL
);
    DROP TABLE public.calisan;
       public         heap    postgres    false            ?            1259    16643    calisan_calisanNo_seq    SEQUENCE     ?   CREATE SEQUENCE public."calisan_calisanNo_seq"
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 .   DROP SEQUENCE public."calisan_calisanNo_seq";
       public          postgres    false    221            ?           0    0    calisan_calisanNo_seq    SEQUENCE OWNED BY     S   ALTER SEQUENCE public."calisan_calisanNo_seq" OWNED BY public.calisan."calisanNo";
          public          postgres    false    220            ?            1259    16629    devamliMusteri    TABLE     ?   CREATE TABLE public."devamliMusteri" (
    "musteriNo" integer NOT NULL,
    "devamliMusteriTC" character varying(11) NOT NULL,
    "indirimID" integer
);
 $   DROP TABLE public."devamliMusteri";
       public         heap    postgres    false            ?            1259    16674    etkinlik    TABLE     S  CREATE TABLE public.etkinlik (
    "etkinlikID" integer NOT NULL,
    "etkinlikAdi" character varying NOT NULL,
    "etkinlikKontenjan" integer NOT NULL,
    "etkinlikTarih" date NOT NULL,
    "hedefKitle" character varying NOT NULL,
    "otelID" integer NOT NULL,
    "etkinlikSaat" character varying NOT NULL,
    "calisanNo" integer
);
    DROP TABLE public.etkinlik;
       public         heap    postgres    false            ?            1259    16673    etkinlik_etkinlikID_seq    SEQUENCE     ?   CREATE SEQUENCE public."etkinlik_etkinlikID_seq"
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 0   DROP SEQUENCE public."etkinlik_etkinlikID_seq";
       public          postgres    false    225            ?           0    0    etkinlik_etkinlikID_seq    SEQUENCE OWNED BY     W   ALTER SEQUENCE public."etkinlik_etkinlikID_seq" OWNED BY public.etkinlik."etkinlikID";
          public          postgres    false    224            ?            1259    16708    gelir    TABLE     ?   CREATE TABLE public.gelir (
    "gelirNo" integer NOT NULL,
    "gelirTuru" character varying(45) NOT NULL,
    "gelirTutar" numeric NOT NULL,
    "otelID" integer NOT NULL,
    "indirimsizTutar" numeric
);
    DROP TABLE public.gelir;
       public         heap    postgres    false            ?            1259    16707    gelir_gelirNo_seq    SEQUENCE     ?   CREATE SEQUENCE public."gelir_gelirNo_seq"
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 *   DROP SEQUENCE public."gelir_gelirNo_seq";
       public          postgres    false    231            ?           0    0    gelir_gelirNo_seq    SEQUENCE OWNED BY     K   ALTER SEQUENCE public."gelir_gelirNo_seq" OWNED BY public.gelir."gelirNo";
          public          postgres    false    230            ?            1259    16699    gider    TABLE     ?   CREATE TABLE public.gider (
    "giderNo" integer NOT NULL,
    "giderTuru" character varying(45) NOT NULL,
    "giderTutar" numeric NOT NULL,
    "otelID" integer NOT NULL,
    "giderTarih" date NOT NULL
);
    DROP TABLE public.gider;
       public         heap    postgres    false            ?            1259    16698    gider_giderNo_seq    SEQUENCE     ?   CREATE SEQUENCE public."gider_giderNo_seq"
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 *   DROP SEQUENCE public."gider_giderNo_seq";
       public          postgres    false    229            ?           0    0    gider_giderNo_seq    SEQUENCE OWNED BY     K   ALTER SEQUENCE public."gider_giderNo_seq" OWNED BY public.gider."giderNo";
          public          postgres    false    228            ?            1259    16635    iletisimBilgileri    TABLE     ?  CREATE TABLE public."iletisimBilgileri" (
    "iletisimID" integer NOT NULL,
    "telefonNo" character varying(11) NOT NULL,
    adres character varying NOT NULL,
    il character varying NOT NULL,
    ilce character varying NOT NULL,
    "postaKodu" character varying NOT NULL,
    "musteriNo" integer,
    "calisanNo" integer,
    "otelID" integer,
    "personelYakiniNo" integer
);
 '   DROP TABLE public."iletisimBilgileri";
       public         heap    postgres    false            ?            1259    16634     iletisimBilgileri_iletisimID_seq    SEQUENCE     ?   CREATE SEQUENCE public."iletisimBilgileri_iletisimID_seq"
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 9   DROP SEQUENCE public."iletisimBilgileri_iletisimID_seq";
       public          postgres    false    219            ?           0    0     iletisimBilgileri_iletisimID_seq    SEQUENCE OWNED BY     k   ALTER SEQUENCE public."iletisimBilgileri_iletisimID_seq" OWNED BY public."iletisimBilgileri"."iletisimID";
          public          postgres    false    218            ?            1259    16803    indirim    TABLE     ?   CREATE TABLE public.indirim (
    "indirimID" integer NOT NULL,
    "personelIndirim" numeric NOT NULL,
    "devamliIndirim" numeric NOT NULL
);
    DROP TABLE public.indirim;
       public         heap    postgres    false            ?            1259    16802    indirim_indirimID_seq    SEQUENCE     ?   CREATE SEQUENCE public."indirim_indirimID_seq"
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 .   DROP SEQUENCE public."indirim_indirimID_seq";
       public          postgres    false    239            ?           0    0    indirim_indirimID_seq    SEQUENCE OWNED BY     S   ALTER SEQUENCE public."indirim_indirimID_seq" OWNED BY public.indirim."indirimID";
          public          postgres    false    238            ?            1259    16652    kadroluCalisan    TABLE     ?   CREATE TABLE public."kadroluCalisan" (
    "calisanNo" integer NOT NULL,
    "kadroluTC" character varying(11) NOT NULL,
    maas numeric NOT NULL
);
 $   DROP TABLE public."kadroluCalisan";
       public         heap    postgres    false            ?            1259    16611    musteri    TABLE     ?  CREATE TABLE public.musteri (
    "musteriNo" integer NOT NULL,
    "musteriAd" character varying(45) NOT NULL,
    "musteriSoyad" character varying(45) NOT NULL,
    "dogumTarihi" date NOT NULL,
    "medeniHal" character varying NOT NULL,
    cinsiyet character varying NOT NULL,
    "musteriTipi" character varying,
    "otelID" integer NOT NULL,
    "sicilNo" character varying(10)
);
    DROP TABLE public.musteri;
       public         heap    postgres    false            ?            1259    16610    müsteri_müsteriNo_seq    SEQUENCE     ?   CREATE SEQUENCE public."müsteri_müsteriNo_seq"
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 0   DROP SEQUENCE public."müsteri_müsteriNo_seq";
       public          postgres    false    215            ?           0    0    müsteri_müsteriNo_seq    SEQUENCE OWNED BY     U   ALTER SEQUENCE public."müsteri_müsteriNo_seq" OWNED BY public.musteri."musteriNo";
          public          postgres    false    214            ?            1259    16725    oda    TABLE     ?   CREATE TABLE public.oda (
    "odaID" integer NOT NULL,
    "odaKat" integer NOT NULL,
    "odaManzara" character varying(45) NOT NULL,
    "odaTurID" integer NOT NULL,
    "odaNo" integer NOT NULL
);
    DROP TABLE public.oda;
       public         heap    postgres    false            ?            1259    16732    odaTur    TABLE     ?   CREATE TABLE public."odaTur" (
    "odaTurID" integer NOT NULL,
    "odaTurAdi" character varying(45) NOT NULL,
    "odaFiyat" numeric NOT NULL
);
    DROP TABLE public."odaTur";
       public         heap    postgres    false            ?            1259    16731    odaTur_odaTurID_seq    SEQUENCE     ?   CREATE SEQUENCE public."odaTur_odaTurID_seq"
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 ,   DROP SEQUENCE public."odaTur_odaTurID_seq";
       public          postgres    false    237            ?           0    0    odaTur_odaTurID_seq    SEQUENCE OWNED BY     Q   ALTER SEQUENCE public."odaTur_odaTurID_seq" OWNED BY public."odaTur"."odaTurID";
          public          postgres    false    236            ?            1259    16724    oda_odaNo_seq    SEQUENCE     ?   CREATE SEQUENCE public."oda_odaNo_seq"
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 &   DROP SEQUENCE public."oda_odaNo_seq";
       public          postgres    false    235            ?           0    0    oda_odaNo_seq    SEQUENCE OWNED BY     C   ALTER SEQUENCE public."oda_odaNo_seq" OWNED BY public.oda."odaID";
          public          postgres    false    234            ?            1259    16683    otel    TABLE     ?   CREATE TABLE public.otel (
    "otelID" integer NOT NULL,
    "otelAdi" character varying(45) NOT NULL,
    "otelSahibi" character varying(45) NOT NULL,
    "kurulusTarihi" date NOT NULL
);
    DROP TABLE public.otel;
       public         heap    postgres    false            ?            1259    16682    otel_otelID_seq    SEQUENCE     ?   CREATE SEQUENCE public."otel_otelID_seq"
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 (   DROP SEQUENCE public."otel_otelID_seq";
       public          postgres    false    227            ?           0    0    otel_otelID_seq    SEQUENCE OWNED BY     G   ALTER SEQUENCE public."otel_otelID_seq" OWNED BY public.otel."otelID";
          public          postgres    false    226            ?            1259    24624    personelYakini    TABLE       CREATE TABLE public."personelYakini" (
    "personelYakiniNo" integer NOT NULL,
    "personelYakiniTC" character varying NOT NULL,
    "personelYakiniAd" character varying NOT NULL,
    "personelYakiniSoyad" character varying NOT NULL,
    "medeniHal" character varying NOT NULL,
    cinsiyet character varying NOT NULL,
    "dogumTarihi" date NOT NULL,
    "otelID" integer NOT NULL,
    "perYakMus" character varying,
    "calisanNo" integer NOT NULL,
    "indirimID" integer,
    "perYakSicilNo" character varying
);
 $   DROP TABLE public."personelYakini";
       public         heap    postgres    false            ?            1259    24634    personelYakiniMusteri    TABLE     ?   CREATE TABLE public."personelYakiniMusteri" (
    "personelYakiniNo" integer NOT NULL,
    "perYakMusTC" character varying NOT NULL,
    "musteriNo" integer NOT NULL
);
 +   DROP TABLE public."personelYakiniMusteri";
       public         heap    postgres    false            ?            1259    24623 #   personelYakini_personelYakiniNo_seq    SEQUENCE     ?   CREATE SEQUENCE public."personelYakini_personelYakiniNo_seq"
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 <   DROP SEQUENCE public."personelYakini_personelYakiniNo_seq";
       public          postgres    false    241            ?           0    0 #   personelYakini_personelYakiniNo_seq    SEQUENCE OWNED BY     q   ALTER SEQUENCE public."personelYakini_personelYakiniNo_seq" OWNED BY public."personelYakini"."personelYakiniNo";
          public          postgres    false    240            ?            1259    16718    rezervasyon    TABLE     ?   CREATE TABLE public.rezervasyon (
    "rezervasyonNo" integer NOT NULL,
    "girisTarih" date NOT NULL,
    "cikisTarih" date NOT NULL,
    "odaID" integer,
    "musteriNo" integer,
    "personelYakiniNo" integer,
    "gelirNo" integer
);
    DROP TABLE public.rezervasyon;
       public         heap    postgres    false            ?            1259    16717    rezervasyon_rezervasyonNo_seq    SEQUENCE     ?   CREATE SEQUENCE public."rezervasyon_rezervasyonNo_seq"
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 6   DROP SEQUENCE public."rezervasyon_rezervasyonNo_seq";
       public          postgres    false    233            ?           0    0    rezervasyon_rezervasyonNo_seq    SEQUENCE OWNED BY     c   ALTER SEQUENCE public."rezervasyon_rezervasyonNo_seq" OWNED BY public.rezervasyon."rezervasyonNo";
          public          postgres    false    232            ?            1259    16659    sezonlukCalisan    TABLE     ?   CREATE TABLE public."sezonlukCalisan" (
    "calisanNo" integer NOT NULL,
    "sezonlukTC" character varying(11) NOT NULL,
    maas numeric NOT NULL,
    "sezonTuru" character varying NOT NULL
);
 %   DROP TABLE public."sezonlukCalisan";
       public         heap    postgres    false            ?            1259    25024    toplamGelir    TABLE     ?   CREATE TABLE public."toplamGelir" (
    "totalGelir" bigint
);
 !   DROP TABLE public."toplamGelir";
       public         heap    postgres    false            ?            1259    25031    toplamGider    TABLE     ?   CREATE TABLE public."toplamGider" (
    "totalGider" bigint
);
 !   DROP TABLE public."toplamGider";
       public         heap    postgres    false            ?            1259    16624    yeniMusteri    TABLE     |   CREATE TABLE public."yeniMusteri" (
    "musteriNo" integer NOT NULL,
    "yeniMusteriTC" character varying(11) NOT NULL
);
 !   DROP TABLE public."yeniMusteri";
       public         heap    postgres    false            ?           2604    16647    calisan calisanNo    DEFAULT     z   ALTER TABLE ONLY public.calisan ALTER COLUMN "calisanNo" SET DEFAULT nextval('public."calisan_calisanNo_seq"'::regclass);
 B   ALTER TABLE public.calisan ALTER COLUMN "calisanNo" DROP DEFAULT;
       public          postgres    false    220    221    221            ?           2604    16677    etkinlik etkinlikID    DEFAULT     ~   ALTER TABLE ONLY public.etkinlik ALTER COLUMN "etkinlikID" SET DEFAULT nextval('public."etkinlik_etkinlikID_seq"'::regclass);
 D   ALTER TABLE public.etkinlik ALTER COLUMN "etkinlikID" DROP DEFAULT;
       public          postgres    false    225    224    225            ?           2604    16711    gelir gelirNo    DEFAULT     r   ALTER TABLE ONLY public.gelir ALTER COLUMN "gelirNo" SET DEFAULT nextval('public."gelir_gelirNo_seq"'::regclass);
 >   ALTER TABLE public.gelir ALTER COLUMN "gelirNo" DROP DEFAULT;
       public          postgres    false    230    231    231            ?           2604    16702    gider giderNo    DEFAULT     r   ALTER TABLE ONLY public.gider ALTER COLUMN "giderNo" SET DEFAULT nextval('public."gider_giderNo_seq"'::regclass);
 >   ALTER TABLE public.gider ALTER COLUMN "giderNo" DROP DEFAULT;
       public          postgres    false    228    229    229            ?           2604    16638    iletisimBilgileri iletisimID    DEFAULT     ?   ALTER TABLE ONLY public."iletisimBilgileri" ALTER COLUMN "iletisimID" SET DEFAULT nextval('public."iletisimBilgileri_iletisimID_seq"'::regclass);
 O   ALTER TABLE public."iletisimBilgileri" ALTER COLUMN "iletisimID" DROP DEFAULT;
       public          postgres    false    219    218    219            ?           2604    16806    indirim indirimID    DEFAULT     z   ALTER TABLE ONLY public.indirim ALTER COLUMN "indirimID" SET DEFAULT nextval('public."indirim_indirimID_seq"'::regclass);
 B   ALTER TABLE public.indirim ALTER COLUMN "indirimID" DROP DEFAULT;
       public          postgres    false    239    238    239            ?           2604    16614    musteri musteriNo    DEFAULT     |   ALTER TABLE ONLY public.musteri ALTER COLUMN "musteriNo" SET DEFAULT nextval('public."müsteri_müsteriNo_seq"'::regclass);
 B   ALTER TABLE public.musteri ALTER COLUMN "musteriNo" DROP DEFAULT;
       public          postgres    false    214    215    215            ?           2604    16728 	   oda odaID    DEFAULT     j   ALTER TABLE ONLY public.oda ALTER COLUMN "odaID" SET DEFAULT nextval('public."oda_odaNo_seq"'::regclass);
 :   ALTER TABLE public.oda ALTER COLUMN "odaID" DROP DEFAULT;
       public          postgres    false    234    235    235            ?           2604    16735    odaTur odaTurID    DEFAULT     x   ALTER TABLE ONLY public."odaTur" ALTER COLUMN "odaTurID" SET DEFAULT nextval('public."odaTur_odaTurID_seq"'::regclass);
 B   ALTER TABLE public."odaTur" ALTER COLUMN "odaTurID" DROP DEFAULT;
       public          postgres    false    236    237    237            ?           2604    16686    otel otelID    DEFAULT     n   ALTER TABLE ONLY public.otel ALTER COLUMN "otelID" SET DEFAULT nextval('public."otel_otelID_seq"'::regclass);
 <   ALTER TABLE public.otel ALTER COLUMN "otelID" DROP DEFAULT;
       public          postgres    false    227    226    227            ?           2604    24627    personelYakini personelYakiniNo    DEFAULT     ?   ALTER TABLE ONLY public."personelYakini" ALTER COLUMN "personelYakiniNo" SET DEFAULT nextval('public."personelYakini_personelYakiniNo_seq"'::regclass);
 R   ALTER TABLE public."personelYakini" ALTER COLUMN "personelYakiniNo" DROP DEFAULT;
       public          postgres    false    240    241    241            ?           2604    16721    rezervasyon rezervasyonNo    DEFAULT     ?   ALTER TABLE ONLY public.rezervasyon ALTER COLUMN "rezervasyonNo" SET DEFAULT nextval('public."rezervasyon_rezervasyonNo_seq"'::regclass);
 J   ALTER TABLE public.rezervasyon ALTER COLUMN "rezervasyonNo" DROP DEFAULT;
       public          postgres    false    233    232    233            ?          0    16644    calisan 
   TABLE DATA           ?   COPY public.calisan ("calisanNo", "calisanAd", "calisanSoyad", "dogumTarihi", "medeniHal", cinsiyet, "calisanTür", "iseGiris", departman, "otelID") FROM stdin;
    public          postgres    false    221   G?       ?          0    16629    devamliMusteri 
   TABLE DATA           X   COPY public."devamliMusteri" ("musteriNo", "devamliMusteriTC", "indirimID") FROM stdin;
    public          postgres    false    217   d?       ?          0    16674    etkinlik 
   TABLE DATA           ?   COPY public.etkinlik ("etkinlikID", "etkinlikAdi", "etkinlikKontenjan", "etkinlikTarih", "hedefKitle", "otelID", "etkinlikSaat", "calisanNo") FROM stdin;
    public          postgres    false    225   ??       ?          0    16708    gelir 
   TABLE DATA           b   COPY public.gelir ("gelirNo", "gelirTuru", "gelirTutar", "otelID", "indirimsizTutar") FROM stdin;
    public          postgres    false    231   ??       ?          0    16699    gider 
   TABLE DATA           ]   COPY public.gider ("giderNo", "giderTuru", "giderTutar", "otelID", "giderTarih") FROM stdin;
    public          postgres    false    229   ??       ?          0    16635    iletisimBilgileri 
   TABLE DATA           ?   COPY public."iletisimBilgileri" ("iletisimID", "telefonNo", adres, il, ilce, "postaKodu", "musteriNo", "calisanNo", "otelID", "personelYakiniNo") FROM stdin;
    public          postgres    false    219   ??       ?          0    16803    indirim 
   TABLE DATA           S   COPY public.indirim ("indirimID", "personelIndirim", "devamliIndirim") FROM stdin;
    public          postgres    false    239   ??       ?          0    16652    kadroluCalisan 
   TABLE DATA           J   COPY public."kadroluCalisan" ("calisanNo", "kadroluTC", maas) FROM stdin;
    public          postgres    false    222   ?       ?          0    16611    musteri 
   TABLE DATA           ?   COPY public.musteri ("musteriNo", "musteriAd", "musteriSoyad", "dogumTarihi", "medeniHal", cinsiyet, "musteriTipi", "otelID", "sicilNo") FROM stdin;
    public          postgres    false    215   9?       ?          0    16725    oda 
   TABLE DATA           S   COPY public.oda ("odaID", "odaKat", "odaManzara", "odaTurID", "odaNo") FROM stdin;
    public          postgres    false    235   V?       ?          0    16732    odaTur 
   TABLE DATA           G   COPY public."odaTur" ("odaTurID", "odaTurAdi", "odaFiyat") FROM stdin;
    public          postgres    false    237   s?       ?          0    16683    otel 
   TABLE DATA           R   COPY public.otel ("otelID", "otelAdi", "otelSahibi", "kurulusTarihi") FROM stdin;
    public          postgres    false    227   ??       ?          0    24624    personelYakini 
   TABLE DATA           ?   COPY public."personelYakini" ("personelYakiniNo", "personelYakiniTC", "personelYakiniAd", "personelYakiniSoyad", "medeniHal", cinsiyet, "dogumTarihi", "otelID", "perYakMus", "calisanNo", "indirimID", "perYakSicilNo") FROM stdin;
    public          postgres    false    241   	?       ?          0    24634    personelYakiniMusteri 
   TABLE DATA           a   COPY public."personelYakiniMusteri" ("personelYakiniNo", "perYakMusTC", "musteriNo") FROM stdin;
    public          postgres    false    242   &?       ?          0    16718    rezervasyon 
   TABLE DATA           ?   COPY public.rezervasyon ("rezervasyonNo", "girisTarih", "cikisTarih", "odaID", "musteriNo", "personelYakiniNo", "gelirNo") FROM stdin;
    public          postgres    false    233   C?       ?          0    16659    sezonlukCalisan 
   TABLE DATA           Y   COPY public."sezonlukCalisan" ("calisanNo", "sezonlukTC", maas, "sezonTuru") FROM stdin;
    public          postgres    false    223   `?       ?          0    25024    toplamGelir 
   TABLE DATA           5   COPY public."toplamGelir" ("totalGelir") FROM stdin;
    public          postgres    false    243   }?       ?          0    25031    toplamGider 
   TABLE DATA           5   COPY public."toplamGider" ("totalGider") FROM stdin;
    public          postgres    false    244   ??       ?          0    16624    yeniMusteri 
   TABLE DATA           E   COPY public."yeniMusteri" ("musteriNo", "yeniMusteriTC") FROM stdin;
    public          postgres    false    216   ??       ?           0    0    calisan_calisanNo_seq    SEQUENCE SET     F   SELECT pg_catalog.setval('public."calisan_calisanNo_seq"', 1, false);
          public          postgres    false    220            ?           0    0    etkinlik_etkinlikID_seq    SEQUENCE SET     H   SELECT pg_catalog.setval('public."etkinlik_etkinlikID_seq"', 1, false);
          public          postgres    false    224            ?           0    0    gelir_gelirNo_seq    SEQUENCE SET     B   SELECT pg_catalog.setval('public."gelir_gelirNo_seq"', 1, false);
          public          postgres    false    230            ?           0    0    gider_giderNo_seq    SEQUENCE SET     B   SELECT pg_catalog.setval('public."gider_giderNo_seq"', 1, false);
          public          postgres    false    228            ?           0    0     iletisimBilgileri_iletisimID_seq    SEQUENCE SET     Q   SELECT pg_catalog.setval('public."iletisimBilgileri_iletisimID_seq"', 1, false);
          public          postgres    false    218            ?           0    0    indirim_indirimID_seq    SEQUENCE SET     F   SELECT pg_catalog.setval('public."indirim_indirimID_seq"', 1, false);
          public          postgres    false    238            ?           0    0    müsteri_müsteriNo_seq    SEQUENCE SET     H   SELECT pg_catalog.setval('public."müsteri_müsteriNo_seq"', 1, false);
          public          postgres    false    214            ?           0    0    odaTur_odaTurID_seq    SEQUENCE SET     D   SELECT pg_catalog.setval('public."odaTur_odaTurID_seq"', 1, false);
          public          postgres    false    236            ?           0    0    oda_odaNo_seq    SEQUENCE SET     >   SELECT pg_catalog.setval('public."oda_odaNo_seq"', 1, false);
          public          postgres    false    234            ?           0    0    otel_otelID_seq    SEQUENCE SET     @   SELECT pg_catalog.setval('public."otel_otelID_seq"', 1, false);
          public          postgres    false    226            ?           0    0 #   personelYakini_personelYakiniNo_seq    SEQUENCE SET     T   SELECT pg_catalog.setval('public."personelYakini_personelYakiniNo_seq"', 1, false);
          public          postgres    false    240            ?           0    0    rezervasyon_rezervasyonNo_seq    SEQUENCE SET     N   SELECT pg_catalog.setval('public."rezervasyon_rezervasyonNo_seq"', 1, false);
          public          postgres    false    232            ?           2606    16651    calisan calisan_pkey 
   CONSTRAINT     [   ALTER TABLE ONLY public.calisan
    ADD CONSTRAINT calisan_pkey PRIMARY KEY ("calisanNo");
 >   ALTER TABLE ONLY public.calisan DROP CONSTRAINT calisan_pkey;
       public            postgres    false    221            ?           2606    24622    devamliMusteri devamliMusteriTC 
   CONSTRAINT     ?   ALTER TABLE ONLY public."devamliMusteri"
    ADD CONSTRAINT "devamliMusteriTC" UNIQUE ("devamliMusteriTC") INCLUDE ("devamliMusteriTC");
 M   ALTER TABLE ONLY public."devamliMusteri" DROP CONSTRAINT "devamliMusteriTC";
       public            postgres    false    217            ?           2606    16633 #   devamliMusteri devamliMüsteri_pkey 
   CONSTRAINT     n   ALTER TABLE ONLY public."devamliMusteri"
    ADD CONSTRAINT "devamliMüsteri_pkey" PRIMARY KEY ("musteriNo");
 Q   ALTER TABLE ONLY public."devamliMusteri" DROP CONSTRAINT "devamliMüsteri_pkey";
       public            postgres    false    217            ?           2606    16681    etkinlik etkinlik_pkey 
   CONSTRAINT     ^   ALTER TABLE ONLY public.etkinlik
    ADD CONSTRAINT etkinlik_pkey PRIMARY KEY ("etkinlikID");
 @   ALTER TABLE ONLY public.etkinlik DROP CONSTRAINT etkinlik_pkey;
       public            postgres    false    225            ?           2606    16715    gelir gelir_pkey 
   CONSTRAINT     U   ALTER TABLE ONLY public.gelir
    ADD CONSTRAINT gelir_pkey PRIMARY KEY ("gelirNo");
 :   ALTER TABLE ONLY public.gelir DROP CONSTRAINT gelir_pkey;
       public            postgres    false    231            ?           2606    16706    gider gider_pkey 
   CONSTRAINT     U   ALTER TABLE ONLY public.gider
    ADD CONSTRAINT gider_pkey PRIMARY KEY ("giderNo");
 :   ALTER TABLE ONLY public.gider DROP CONSTRAINT gider_pkey;
       public            postgres    false    229            ?           2606    16642 (   iletisimBilgileri iletisimBilgileri_pkey 
   CONSTRAINT     t   ALTER TABLE ONLY public."iletisimBilgileri"
    ADD CONSTRAINT "iletisimBilgileri_pkey" PRIMARY KEY ("iletisimID");
 V   ALTER TABLE ONLY public."iletisimBilgileri" DROP CONSTRAINT "iletisimBilgileri_pkey";
       public            postgres    false    219                        2606    16810    indirim indirim_pkey 
   CONSTRAINT     [   ALTER TABLE ONLY public.indirim
    ADD CONSTRAINT indirim_pkey PRIMARY KEY ("indirimID");
 >   ALTER TABLE ONLY public.indirim DROP CONSTRAINT indirim_pkey;
       public            postgres    false    239            ?           2606    16658 "   kadroluCalisan kadroluCalisan_pkey 
   CONSTRAINT     m   ALTER TABLE ONLY public."kadroluCalisan"
    ADD CONSTRAINT "kadroluCalisan_pkey" PRIMARY KEY ("calisanNo");
 P   ALTER TABLE ONLY public."kadroluCalisan" DROP CONSTRAINT "kadroluCalisan_pkey";
       public            postgres    false    222            ?           2606    24614    kadroluCalisan kadroluTC 
   CONSTRAINT     t   ALTER TABLE ONLY public."kadroluCalisan"
    ADD CONSTRAINT "kadroluTC" UNIQUE ("kadroluTC") INCLUDE ("kadroluTC");
 F   ALTER TABLE ONLY public."kadroluCalisan" DROP CONSTRAINT "kadroluTC";
       public            postgres    false    222            ?           2606    16618    musteri müsteri_pkey 
   CONSTRAINT     ^   ALTER TABLE ONLY public.musteri
    ADD CONSTRAINT "müsteri_pkey" PRIMARY KEY ("musteriNo");
 A   ALTER TABLE ONLY public.musteri DROP CONSTRAINT "müsteri_pkey";
       public            postgres    false    215            ?           2606    24612 	   oda odaNo 
   CONSTRAINT     [   ALTER TABLE ONLY public.oda
    ADD CONSTRAINT "odaNo" UNIQUE ("odaNo") INCLUDE ("odaNo");
 5   ALTER TABLE ONLY public.oda DROP CONSTRAINT "odaNo";
       public            postgres    false    235            ?           2606    16739    odaTur odaTur_pkey 
   CONSTRAINT     \   ALTER TABLE ONLY public."odaTur"
    ADD CONSTRAINT "odaTur_pkey" PRIMARY KEY ("odaTurID");
 @   ALTER TABLE ONLY public."odaTur" DROP CONSTRAINT "odaTur_pkey";
       public            postgres    false    237            ?           2606    16730    oda oda_pkey 
   CONSTRAINT     O   ALTER TABLE ONLY public.oda
    ADD CONSTRAINT oda_pkey PRIMARY KEY ("odaID");
 6   ALTER TABLE ONLY public.oda DROP CONSTRAINT oda_pkey;
       public            postgres    false    235            ?           2606    16688    otel otel_pkey 
   CONSTRAINT     R   ALTER TABLE ONLY public.otel
    ADD CONSTRAINT otel_pkey PRIMARY KEY ("otelID");
 8   ALTER TABLE ONLY public.otel DROP CONSTRAINT otel_pkey;
       public            postgres    false    227            	           2606    24642 !   personelYakiniMusteri perYakMusTC 
   CONSTRAINT     ?   ALTER TABLE ONLY public."personelYakiniMusteri"
    ADD CONSTRAINT "perYakMusTC" UNIQUE ("perYakMusTC") INCLUDE ("perYakMusTC");
 O   ALTER TABLE ONLY public."personelYakiniMusteri" DROP CONSTRAINT "perYakMusTC";
       public            postgres    false    242                       2606    24693    personelYakini perYakSicilNo 
   CONSTRAINT     ?   ALTER TABLE ONLY public."personelYakini"
    ADD CONSTRAINT "perYakSicilNo" UNIQUE ("perYakSicilNo") INCLUDE ("perYakSicilNo");
 J   ALTER TABLE ONLY public."personelYakini" DROP CONSTRAINT "perYakSicilNo";
       public            postgres    false    241                       2606    24640 0   personelYakiniMusteri personelYakiniMusteri_pkey 
   CONSTRAINT     ?   ALTER TABLE ONLY public."personelYakiniMusteri"
    ADD CONSTRAINT "personelYakiniMusteri_pkey" PRIMARY KEY ("personelYakiniNo");
 ^   ALTER TABLE ONLY public."personelYakiniMusteri" DROP CONSTRAINT "personelYakiniMusteri_pkey";
       public            postgres    false    242                       2606    24633    personelYakini personelYakiniTC 
   CONSTRAINT     ?   ALTER TABLE ONLY public."personelYakini"
    ADD CONSTRAINT "personelYakiniTC" UNIQUE ("personelYakiniTC") INCLUDE ("personelYakiniTC");
 M   ALTER TABLE ONLY public."personelYakini" DROP CONSTRAINT "personelYakiniTC";
       public            postgres    false    241                       2606    24631 "   personelYakini personelYakini_pkey 
   CONSTRAINT     t   ALTER TABLE ONLY public."personelYakini"
    ADD CONSTRAINT "personelYakini_pkey" PRIMARY KEY ("personelYakiniNo");
 P   ALTER TABLE ONLY public."personelYakini" DROP CONSTRAINT "personelYakini_pkey";
       public            postgres    false    241            ?           2606    16723    rezervasyon rezervasyon_pkey 
   CONSTRAINT     g   ALTER TABLE ONLY public.rezervasyon
    ADD CONSTRAINT rezervasyon_pkey PRIMARY KEY ("rezervasyonNo");
 F   ALTER TABLE ONLY public.rezervasyon DROP CONSTRAINT rezervasyon_pkey;
       public            postgres    false    233            ?           2606    16665 $   sezonlukCalisan sezonlukCalisan_pkey 
   CONSTRAINT     o   ALTER TABLE ONLY public."sezonlukCalisan"
    ADD CONSTRAINT "sezonlukCalisan_pkey" PRIMARY KEY ("calisanNo");
 R   ALTER TABLE ONLY public."sezonlukCalisan" DROP CONSTRAINT "sezonlukCalisan_pkey";
       public            postgres    false    223            ?           2606    24610    sezonlukCalisan sezonlukTC 
   CONSTRAINT     x   ALTER TABLE ONLY public."sezonlukCalisan"
    ADD CONSTRAINT "sezonlukTC" UNIQUE ("sezonlukTC") INCLUDE ("sezonlukTC");
 H   ALTER TABLE ONLY public."sezonlukCalisan" DROP CONSTRAINT "sezonlukTC";
       public            postgres    false    223            ?           2606    24691    musteri sicilNo 
   CONSTRAINT     e   ALTER TABLE ONLY public.musteri
    ADD CONSTRAINT "sicilNo" UNIQUE ("sicilNo") INCLUDE ("sicilNo");
 ;   ALTER TABLE ONLY public.musteri DROP CONSTRAINT "sicilNo";
       public            postgres    false    215            ?           2606    24616    iletisimBilgileri telefonNo 
   CONSTRAINT     w   ALTER TABLE ONLY public."iletisimBilgileri"
    ADD CONSTRAINT "telefonNo" UNIQUE ("telefonNo") INCLUDE ("telefonNo");
 I   ALTER TABLE ONLY public."iletisimBilgileri" DROP CONSTRAINT "telefonNo";
       public            postgres    false    219            ?           2606    24606    yeniMusteri yeniMusteriTC 
   CONSTRAINT     }   ALTER TABLE ONLY public."yeniMusteri"
    ADD CONSTRAINT "yeniMusteriTC" UNIQUE ("yeniMusteriTC") INCLUDE ("yeniMusteriTC");
 G   ALTER TABLE ONLY public."yeniMusteri" DROP CONSTRAINT "yeniMusteriTC";
       public            postgres    false    216            ?           2606    16628    yeniMusteri yeniMüsteri_pkey 
   CONSTRAINT     h   ALTER TABLE ONLY public."yeniMusteri"
    ADD CONSTRAINT "yeniMüsteri_pkey" PRIMARY KEY ("musteriNo");
 K   ALTER TABLE ONLY public."yeniMusteri" DROP CONSTRAINT "yeniMüsteri_pkey";
       public            postgres    false    216            ?           1259    16828    fki_c    INDEX     L   CREATE INDEX fki_c ON public."iletisimBilgileri" USING btree ("musteriNo");
    DROP INDEX public.fki_c;
       public            postgres    false    219            ?           1259    16834    fki_calisanNo    INDEX     V   CREATE INDEX "fki_calisanNo" ON public."iletisimBilgileri" USING btree ("calisanNo");
 #   DROP INDEX public."fki_calisanNo";
       public            postgres    false    219            ?           1259    16888    fki_e    INDEX     I   CREATE INDEX fki_e ON public."devamliMusteri" USING btree ("musteriNo");
    DROP INDEX public.fki_e;
       public            postgres    false    217                       1259    24653    fki_musteriNo    INDEX     Z   CREATE INDEX "fki_musteriNo" ON public."personelYakiniMusteri" USING btree ("musteriNo");
 #   DROP INDEX public."fki_musteriNo";
       public            postgres    false    242            ?           1259    16909 	   fki_odaNo    INDEX     F   CREATE INDEX "fki_odaNo" ON public.rezervasyon USING btree ("odaID");
    DROP INDEX public."fki_odaNo";
       public            postgres    false    233            ?           1259    16926    fki_odaTurID    INDEX     D   CREATE INDEX "fki_odaTurID" ON public.oda USING btree ("odaTurID");
 "   DROP INDEX public."fki_odaTurID";
       public            postgres    false    235            ?           1259    16816 
   fki_otelID    INDEX     D   CREATE INDEX "fki_otelID" ON public.musteri USING btree ("otelID");
     DROP INDEX public."fki_otelID";
       public            postgres    false    215            ?           1259    24659    fki_personelYakiniNo    INDEX     d   CREATE INDEX "fki_personelYakiniNo" ON public."iletisimBilgileri" USING btree ("personelYakiniNo");
 *   DROP INDEX public."fki_personelYakiniNo";
       public            postgres    false    219            ?           1259    16840    fki_t    INDEX     I   CREATE INDEX fki_t ON public."iletisimBilgileri" USING btree ("otelID");
    DROP INDEX public.fki_t;
       public            postgres    false    219            '           2620    25038    etkinlik kontroltrig    TRIGGER     u   CREATE TRIGGER kontroltrig BEFORE INSERT ON public.etkinlik FOR EACH ROW EXECUTE FUNCTION public.kontrolkontenjan();
 -   DROP TRIGGER kontroltrig ON public.etkinlik;
       public          postgres    false    225    253            %           2620    25014    musteri musterisiciltrig    TRIGGER     ~   CREATE TRIGGER musterisiciltrig BEFORE INSERT ON public.musteri FOR EACH ROW EXECUTE FUNCTION public.musterisicilnokontrol();
 1   DROP TRIGGER musterisiciltrig ON public.musteri;
       public          postgres    false    215    246            (           2620    25023    oda odasayitrig    TRIGGER     i   CREATE TRIGGER odasayitrig BEFORE INSERT ON public.oda FOR EACH ROW EXECUTE FUNCTION public.odasayisi();
 (   DROP TRIGGER odasayitrig ON public.oda;
       public          postgres    false    247    235            )           2620    25012    personelYakini personeltrig    TRIGGER     ?   CREATE TRIGGER personeltrig BEFORE INSERT ON public."personelYakini" FOR EACH ROW EXECUTE FUNCTION public.personelsicilnokontrol();
 6   DROP TRIGGER personeltrig ON public."personelYakini";
       public          postgres    false    241    245            &           2620    25036 "   iletisimBilgileri telefonnumarası    TRIGGER     ?   CREATE TRIGGER "telefonnumarası" BEFORE INSERT ON public."iletisimBilgileri" FOR EACH ROW EXECUTE FUNCTION public.telefonno();
 ?   DROP TRIGGER "telefonnumarası" ON public."iletisimBilgileri";
       public          postgres    false    219    252                       2606    16829    iletisimBilgileri calisanNo    FK CONSTRAINT     ?   ALTER TABLE ONLY public."iletisimBilgileri"
    ADD CONSTRAINT "calisanNo" FOREIGN KEY ("calisanNo") REFERENCES public.calisan("calisanNo") NOT VALID;
 I   ALTER TABLE ONLY public."iletisimBilgileri" DROP CONSTRAINT "calisanNo";
       public          postgres    false    219    221    3300                       2606    16846    kadroluCalisan calisanNo    FK CONSTRAINT     ?   ALTER TABLE ONLY public."kadroluCalisan"
    ADD CONSTRAINT "calisanNo" FOREIGN KEY ("calisanNo") REFERENCES public.calisan("calisanNo") NOT VALID;
 F   ALTER TABLE ONLY public."kadroluCalisan" DROP CONSTRAINT "calisanNo";
       public          postgres    false    3300    221    222                       2606    16851    sezonlukCalisan calisanNo    FK CONSTRAINT     ?   ALTER TABLE ONLY public."sezonlukCalisan"
    ADD CONSTRAINT "calisanNo" FOREIGN KEY ("calisanNo") REFERENCES public.calisan("calisanNo") NOT VALID;
 G   ALTER TABLE ONLY public."sezonlukCalisan" DROP CONSTRAINT "calisanNo";
       public          postgres    false    223    221    3300                        2606    24665    personelYakini calisanNo    FK CONSTRAINT     ?   ALTER TABLE ONLY public."personelYakini"
    ADD CONSTRAINT "calisanNo" FOREIGN KEY ("calisanNo") REFERENCES public.calisan("calisanNo") NOT VALID;
 F   ALTER TABLE ONLY public."personelYakini" DROP CONSTRAINT "calisanNo";
       public          postgres    false    3300    221    241                       2606    24699    etkinlik calisanNo    FK CONSTRAINT     ?   ALTER TABLE ONLY public.etkinlik
    ADD CONSTRAINT "calisanNo" FOREIGN KEY ("calisanNo") REFERENCES public.calisan("calisanNo") NOT VALID;
 >   ALTER TABLE ONLY public.etkinlik DROP CONSTRAINT "calisanNo";
       public          postgres    false    221    225    3300                       2606    24704    rezervasyon gelirNo    FK CONSTRAINT     ?   ALTER TABLE ONLY public.rezervasyon
    ADD CONSTRAINT "gelirNo" FOREIGN KEY ("gelirNo") REFERENCES public.gelir("gelirNo") NOT VALID;
 ?   ALTER TABLE ONLY public.rezervasyon DROP CONSTRAINT "gelirNo";
       public          postgres    false    233    3316    231                       2606    24675    devamliMusteri indirimID    FK CONSTRAINT     ?   ALTER TABLE ONLY public."devamliMusteri"
    ADD CONSTRAINT "indirimID" FOREIGN KEY ("indirimID") REFERENCES public.indirim("indirimID") NOT VALID;
 F   ALTER TABLE ONLY public."devamliMusteri" DROP CONSTRAINT "indirimID";
       public          postgres    false    3328    239    217            !           2606    24680    personelYakini indirimID    FK CONSTRAINT     ?   ALTER TABLE ONLY public."personelYakini"
    ADD CONSTRAINT "indirimID" FOREIGN KEY ("indirimID") REFERENCES public.indirim("indirimID") NOT VALID;
 F   ALTER TABLE ONLY public."personelYakini" DROP CONSTRAINT "indirimID";
       public          postgres    false    3328    241    239                       2606    16823    iletisimBilgileri musteriNo    FK CONSTRAINT     ?   ALTER TABLE ONLY public."iletisimBilgileri"
    ADD CONSTRAINT "musteriNo" FOREIGN KEY ("musteriNo") REFERENCES public.musteri("musteriNo") NOT VALID;
 I   ALTER TABLE ONLY public."iletisimBilgileri" DROP CONSTRAINT "musteriNo";
       public          postgres    false    219    215    3279                       2606    16878    yeniMusteri musteriNo    FK CONSTRAINT     ?   ALTER TABLE ONLY public."yeniMusteri"
    ADD CONSTRAINT "musteriNo" FOREIGN KEY ("musteriNo") REFERENCES public.musteri("musteriNo") NOT VALID;
 C   ALTER TABLE ONLY public."yeniMusteri" DROP CONSTRAINT "musteriNo";
       public          postgres    false    215    3279    216                       2606    16883    devamliMusteri musteriNo    FK CONSTRAINT     ?   ALTER TABLE ONLY public."devamliMusteri"
    ADD CONSTRAINT "musteriNo" FOREIGN KEY ("musteriNo") REFERENCES public.musteri("musteriNo") NOT VALID;
 F   ALTER TABLE ONLY public."devamliMusteri" DROP CONSTRAINT "musteriNo";
       public          postgres    false    215    217    3279                       2606    16916    rezervasyon musteriNo    FK CONSTRAINT     ?   ALTER TABLE ONLY public.rezervasyon
    ADD CONSTRAINT "musteriNo" FOREIGN KEY ("musteriNo") REFERENCES public.musteri("musteriNo") NOT VALID;
 A   ALTER TABLE ONLY public.rezervasyon DROP CONSTRAINT "musteriNo";
       public          postgres    false    3279    215    233            #           2606    24648    personelYakiniMusteri musteriNo    FK CONSTRAINT     ?   ALTER TABLE ONLY public."personelYakiniMusteri"
    ADD CONSTRAINT "musteriNo" FOREIGN KEY ("musteriNo") REFERENCES public.musteri("musteriNo") NOT VALID;
 M   ALTER TABLE ONLY public."personelYakiniMusteri" DROP CONSTRAINT "musteriNo";
       public          postgres    false    3279    215    242                       2606    16904    rezervasyon odaID    FK CONSTRAINT        ALTER TABLE ONLY public.rezervasyon
    ADD CONSTRAINT "odaID" FOREIGN KEY ("odaID") REFERENCES public.oda("odaID") NOT VALID;
 =   ALTER TABLE ONLY public.rezervasyon DROP CONSTRAINT "odaID";
       public          postgres    false    235    3324    233                       2606    16921    oda odaTurID    FK CONSTRAINT     ?   ALTER TABLE ONLY public.oda
    ADD CONSTRAINT "odaTurID" FOREIGN KEY ("odaTurID") REFERENCES public."odaTur"("odaTurID") NOT VALID;
 8   ALTER TABLE ONLY public.oda DROP CONSTRAINT "odaTurID";
       public          postgres    false    237    235    3326                       2606    16811    musteri otelID    FK CONSTRAINT        ALTER TABLE ONLY public.musteri
    ADD CONSTRAINT "otelID" FOREIGN KEY ("otelID") REFERENCES public.otel("otelID") NOT VALID;
 :   ALTER TABLE ONLY public.musteri DROP CONSTRAINT "otelID";
       public          postgres    false    215    3312    227                       2606    16835    iletisimBilgileri otelID    FK CONSTRAINT     ?   ALTER TABLE ONLY public."iletisimBilgileri"
    ADD CONSTRAINT "otelID" FOREIGN KEY ("otelID") REFERENCES public.otel("otelID") NOT VALID;
 F   ALTER TABLE ONLY public."iletisimBilgileri" DROP CONSTRAINT "otelID";
       public          postgres    false    219    227    3312                       2606    16841    calisan otelID    FK CONSTRAINT        ALTER TABLE ONLY public.calisan
    ADD CONSTRAINT "otelID" FOREIGN KEY ("otelID") REFERENCES public.otel("otelID") NOT VALID;
 :   ALTER TABLE ONLY public.calisan DROP CONSTRAINT "otelID";
       public          postgres    false    3312    227    221                       2606    16889    etkinlik otelID    FK CONSTRAINT     ?   ALTER TABLE ONLY public.etkinlik
    ADD CONSTRAINT "otelID" FOREIGN KEY ("otelID") REFERENCES public.otel("otelID") NOT VALID;
 ;   ALTER TABLE ONLY public.etkinlik DROP CONSTRAINT "otelID";
       public          postgres    false    3312    225    227                       2606    16894    gelir otelID    FK CONSTRAINT     }   ALTER TABLE ONLY public.gelir
    ADD CONSTRAINT "otelID" FOREIGN KEY ("otelID") REFERENCES public.otel("otelID") NOT VALID;
 8   ALTER TABLE ONLY public.gelir DROP CONSTRAINT "otelID";
       public          postgres    false    3312    231    227                       2606    16899    gider otelID    FK CONSTRAINT     }   ALTER TABLE ONLY public.gider
    ADD CONSTRAINT "otelID" FOREIGN KEY ("otelID") REFERENCES public.otel("otelID") NOT VALID;
 8   ALTER TABLE ONLY public.gider DROP CONSTRAINT "otelID";
       public          postgres    false    229    227    3312            "           2606    24660    personelYakini otelID    FK CONSTRAINT     ?   ALTER TABLE ONLY public."personelYakini"
    ADD CONSTRAINT "otelID" FOREIGN KEY ("otelID") REFERENCES public.otel("otelID") NOT VALID;
 C   ALTER TABLE ONLY public."personelYakini" DROP CONSTRAINT "otelID";
       public          postgres    false    241    227    3312                       2606    24654 "   iletisimBilgileri personelYakiniNo    FK CONSTRAINT     ?   ALTER TABLE ONLY public."iletisimBilgileri"
    ADD CONSTRAINT "personelYakiniNo" FOREIGN KEY ("personelYakiniNo") REFERENCES public."personelYakini"("personelYakiniNo") NOT VALID;
 P   ALTER TABLE ONLY public."iletisimBilgileri" DROP CONSTRAINT "personelYakiniNo";
       public          postgres    false    241    3334    219                       2606    24685    rezervasyon personelYakiniNo    FK CONSTRAINT     ?   ALTER TABLE ONLY public.rezervasyon
    ADD CONSTRAINT "personelYakiniNo" FOREIGN KEY ("personelYakiniNo") REFERENCES public."personelYakiniMusteri"("personelYakiniNo") NOT VALID;
 H   ALTER TABLE ONLY public.rezervasyon DROP CONSTRAINT "personelYakiniNo";
       public          postgres    false    3339    233    242            $           2606    24694 &   personelYakiniMusteri personelYakiniNo    FK CONSTRAINT     ?   ALTER TABLE ONLY public."personelYakiniMusteri"
    ADD CONSTRAINT "personelYakiniNo" FOREIGN KEY ("personelYakiniNo") REFERENCES public."personelYakini"("personelYakiniNo") NOT VALID;
 T   ALTER TABLE ONLY public."personelYakiniMusteri" DROP CONSTRAINT "personelYakiniNo";
       public          postgres    false    3334    241    242            ?      x?????? ? ?      ?      x?????? ? ?      ?      x?????? ? ?      ?      x?????? ? ?      ?      x?????? ? ?      ?      x?????? ? ?      ?      x?3?460?465?????? l!      ?      x?????? ? ?      ?      x?????? ? ?      ?      x?????? ? ?      ?   @   x?3?t?/M?IU?OI?4535?2?t?L+Q??,???????rr?f????&F?\1z\\\ (^      ?   6   x?3??ru?V??q??.MIU???N??O?)?4200?50"?=... CB5      ?      x?????? ? ?      ?      x?????? ? ?      ?      x?????? ? ?      ?      x?????? ? ?      ?      x?????? ? ?      ?      x?????? ? ?      ?      x?????? ? ?     