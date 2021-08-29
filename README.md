# ASProjekat (PC Store API)
School project 

"initial" migracija ukljucuje i pocetne podatke za tabele Products(8), Brands(3), Users(2- jedan superuser i jedan obican user) i UserUseCase(25) za korisnike 

- paginacija je podesena na 5 rezultata po stranici
- validacija je odradjenja za svaki potrebni podatak
- swagger je postavljen
- baza podataka je napravljena i popunjena code first pristupom
- autorizacije se vrsi upotrebom Jwt-a
- use caseovi su granulirani za svaku komandu i upit
- email se salje nakon uspesne registracije
- svaki endpoint vraca statusne kodove u zavisnosti od uspeha ili izuzetka
- loguje se svako izvrsavanje bilo kog use case-a, a mogu se i pretraziti log kontrolerom
- automapper je koriscen za mapairanje svakog Dto objekta

Use case-ove sam podesio tako da superuser moze da izvesi sve i on se loguje sa   "adminuser"   "sifra123"  (jwt token je postavljen da istice za vise od pola sata), pored toga neautorizovan korisnik moze da odradi get brendova (svih i po id-u), get produkta (svih i po id-u) kao i da odradi register i login, a autorizovan korisnik pored toga moze da odradi i postavljanje ordera (kupovinu) kao i da vidi svoje porudzbine.

Slika dijagrama baze je u fajlovima projekta.
