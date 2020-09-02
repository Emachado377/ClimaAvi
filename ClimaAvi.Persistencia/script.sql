create table usuario(
id uuid primary Key,
codigo Integer not null,
nome varchar (50) not null,
sobrenome varchar (50) not null,
email varchar (50) not null,
senha varchar (50) not null
)

create table plantas(
id uuid primary Key,
codigo Integer not null,
nome varchar (50) not null,
local varchar (50) not null,
machost varchar (50) not null
)

create table barometro(
id uuid primary Key,
altitude numeric not null,
temperatura numeric not null,
pressaoAtmosferica numeric not null,
umidadear numeric not null,
leitura date not null,
machost varchar (50) not null
)

create table sensorgas(
id uuid primary Key,
metano numeric not null,
propeno numeric not null,
hidrogenio numeric not null,
fumaca numeric not null,
leitura date not null,
machost varchar (50) not null
)

insert into usuario (codigo,nome,sobrenome,email,senha)
values (10,'ruan','ferreira','ruan@gamil.com','11111');

insert into usuario (codigo,nome,sobrenome,email,senha)
values (10,'evandro','machado','evandro@gamil.com','11111');

insert into usuario (codigo,nome,sobrenome,email,senha)
values (10,'parateste','teste1','para@gamil.com','11111');
