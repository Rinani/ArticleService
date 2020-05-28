GET Articles 
Returns this page

GET Articles/{id}
Return specificed Article
Parameter id: The ID of the article to return
Returns Article or 404 if not found

GET Articles/ALL
Returns list of all Articles

POST Articles
Adds article to list
Paramters:
type: application/json
Body:
Serialized Article object
-or-
string author - The Author of the article
string headline - The Headline of the article
int year - The year of the article
string text - The content of the article

DELETE Articles/{id}
Removes an article from the list
Paramter id: The ID of the article to delete
Returns a confirmation on deletion or 404 if not found



- Hvilke overvejelser bør man gøre i forhold til at være i stand til at afvikle det samme docker image i flere forskellige miljøer? Fx en lokal udviklermaskine, en bygge server og en produktionsserver. 
En byggeserver vil tjekke koden ud og selv bygge imaget til test og måske derefter deploy til repository/servere
Til test maskiner og servere er der to primære metoder til at få imaget over. Enten via et docker image repository eller manuelt via at flytte image filen, lavet via docker save og docker load på target.
Efter at imaget er loaded så vil en docker run kunne starte servicen ud fra entry pointet specificeret i docker filen.
f.eks:
docker run -it --rm -p 3000:80 --name articleservicecontainer articleservice



- Du behøver ikke at tilføje authentication til din web service, men foreslå en protokol/metode og begrund dit valg.
Til authentication er det nemmeste og mest benyttede nu en token baseret authentication, som OAuth2 eller JWT, token baseret authentication har den fordel at man ikke sender rå credentials til serveren hele tiden som giver et ekstra lag af sikkerhed i forhold til det individuelle login, udover HTTPS.



- Hvordan kan man lave servicen redundant? Hvilke overvejelser bør man foretage sig? 
Redundans kræver nogle overvejelser, hvor kritisk er en service, hvor brugt er den? En meget brugt og kritisk service, bør have loadbalancing og måske mulighed for at spinne ekstra services op med stor belastning. En lidt brugt med kritisk service kan måske have en backup service kørende hvis den går ned. 
I forhold til database brug, så vil der være mulighed for at køre noget loadbalancing via HAProxy på AWS.



- Hvordan vil du designe og implementere en søgefunktion?
Til søgning er der en række overvejelser der skal gøres for at kunne give den optimale søgningg. Der findes flere forskellige søge løsninger som alle har deres fordele og ulemper at efter hvad ens krav er. Nogle eksempler på ting der skal overvejes før man vælger den rigtige søgeløsning kunne være:
Skal søgning være full text eller baseret på keywords
Når man har fundet nogle resultater, så skal de præsenteres, her skal der nogle overvejelser til for at skabe mest relevans for brugeren. Vægt af tid, måske hits eller evt. engangement, samt referencer. 