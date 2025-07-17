<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "c3f4ea5732d64bf965e8aa2907759709",
  "translation_date": "2025-07-17T08:53:05+00:00",
  "source_file": "02-Security/mcp-security-best-practices-2025.md",
  "language_code": "fi"
}
-->
# MCP:n turvallisuuden parhaat käytännöt – heinäkuun 2025 päivitys

## Kattavat turvallisuuden parhaat käytännöt MCP-toteutuksille

Työskennellessäsi MCP-palvelimien kanssa noudata näitä turvallisuuden parhaita käytäntöjä suojataksesi tietosi, infrastruktuurisi ja käyttäjäsi:

1. **Syötteen validointi**: Varmista aina syötteiden validointi ja puhdistus estääksesi injektiohyökkäykset ja sekaannusongelmat.
   - Toteuta tiukka validointi kaikille työkalun parametreille
   - Käytä skeemavalidointia varmistaaksesi, että pyynnöt vastaavat odotettuja muotoja
   - Suodata mahdollisesti haitalliset sisällöt ennen käsittelyä

2. **Käyttöoikeuksien hallinta**: Toteuta asianmukainen todennus ja valtuutus MCP-palvelimellesi hienojakoisilla käyttöoikeuksilla.
   - Käytä OAuth 2.0:aa tunnetuilla identiteetin tarjoajilla, kuten Microsoft Entra ID:llä
   - Toteuta roolipohjainen käyttöoikeuksien hallinta (RBAC) MCP-työkaluille
   - Älä koskaan tee omaa todennusta, kun olemassa on vakiintuneita ratkaisuja

3. **Turvallinen viestintä**: Käytä HTTPS/TLS:ää kaikessa viestinnässä MCP-palvelimesi kanssa ja harkitse lisäsalausta arkaluontoisille tiedoille.
   - Määritä TLS 1.3 aina kun mahdollista
   - Toteuta sertifikaattien pinnaus kriittisissä yhteyksissä
   - Kierrätä sertifikaatteja säännöllisesti ja varmista niiden voimassaolo

4. **Nopeusrajoitukset**: Toteuta nopeusrajoitukset väärinkäytösten, DoS-hyökkäysten ja resurssien hallinnan estämiseksi.
   - Aseta sopivat pyyntörajoitukset odotettujen käyttökuvioiden mukaan
   - Toteuta porrastettu reagointi liiallisiin pyyntöihin
   - Harkitse käyttäjäkohtaisia nopeusrajoituksia todennustilan perusteella

5. **Lokitus ja valvonta**: Valvo MCP-palvelintasi epäilyttävän toiminnan varalta ja toteuta kattavat auditointilokit.
   - Kirjaa kaikki todennusyritykset ja työkalujen kutsut
   - Toteuta reaaliaikaiset hälytykset epäilyttävistä kuvioista
   - Varmista, että lokit säilytetään turvallisesti eikä niihin voi kajota

6. **Turvallinen tallennus**: Suojaa arkaluontoiset tiedot ja tunnistetiedot asianmukaisella levyllä tapahtuvalla salauksella.
   - Käytä avainholveja tai turvallisia tunnistetietovarastoja kaikille salaisuuksille
   - Toteuta kenttäkohtainen salaus arkaluontoisille tiedoille
   - Kierrätä salausavaimia ja tunnistetietoja säännöllisesti

7. **Tokenien hallinta**: Estä tokenien läpivientiin liittyvät haavoittuvuudet validoimalla ja puhdistamalla kaikki mallin syötteet ja tulosteet.
   - Toteuta tokenien validointi vastaanottajavaatimusten perusteella
   - Älä koskaan hyväksy tokeneita, joita ei ole nimenomaisesti myönnetty MCP-palvelimellesi
   - Toteuta asianmukainen tokenien elinkaaren hallinta ja kierrätys

8. **Istunnon hallinta**: Toteuta turvallinen istuntojen käsittely estääksesi istunnon kaappauksen ja kiinnityshyökkäykset.
   - Käytä turvallisia, ei-deterministisiä istuntotunnuksia
   - Sidota istunnot käyttäjäkohtaisiin tietoihin
   - Toteuta asianmukainen istunnon vanheneminen ja kierrätys

9. **Työkalujen suorituksen eristäminen**: Suorita työkalut eristetyissä ympäristöissä estääksesi sivuttaisliikkeet, jos järjestelmä vaarantuu.
   - Toteuta konttien eristys työkalujen suoritukselle
   - Aseta resurssirajoituksia estääksesi resurssien loppumishyökkäykset
   - Käytä erillisiä suorituskonteksteja eri turvallisuusalueille

10. **Säännölliset turvallisuustarkastukset**: Suorita ajoittain turvallisuusarviointeja MCP-toteutuksillesi ja niiden riippuvuuksille.
    - Aikatauluta säännölliset tunkeutumistestaukset
    - Käytä automatisoituja skannausvälineitä haavoittuvuuksien havaitsemiseen
    - Pidä riippuvuudet ajan tasalla tunnettuja turvallisuusongelmia varten

11. **Sisällön turvallisuussuodatus**: Toteuta sisällön turvallisuussuodattimet sekä syötteille että tulosteille.
    - Käytä Azure Content Safetyä tai vastaavia palveluita haitallisen sisällön tunnistamiseen
    - Toteuta kehotteen suojaustekniikoita kehotteen injektion estämiseksi
    - Skannaa luotu sisältö mahdollisen arkaluontoisen tiedon vuodon varalta

12. **Toimitusketjun turvallisuus**: Varmista kaikkien tekoälytoimitusketjun komponenttien eheys ja aitous.
    - Käytä allekirjoitettuja paketteja ja varmista allekirjoitukset
    - Toteuta ohjelmiston materiaaliluettelon (SBOM) analyysi
    - Valvo riippuvuuksien haitallisia päivityksiä

13. **Työkalumäärittelyjen suojaus**: Estä työkalujen myrkytys suojaamalla työkalumäärittelyt ja metatiedot.
    - Varmista työkalumäärittelyt ennen käyttöä
    - Valvo odottamattomia muutoksia työkalujen metatiedoissa
    - Toteuta eheystarkistukset työkalumäärittelyille

14. **Dynaaminen suorituksen valvonta**: Valvo MCP-palvelimien ja työkalujen suorituksen käyttäytymistä.
    - Toteuta käyttäytymisanalyysi poikkeamien havaitsemiseksi
    - Aseta hälytykset odottamattomille suorituskäytöksille
    - Käytä runtime application self-protection (RASP) -tekniikoita

15. **Vähimmän oikeuden periaate**: Varmista, että MCP-palvelimet ja työkalut toimivat vain välttämättömillä käyttöoikeuksilla.
    - Myönnä vain kunkin toiminnon vaatimat käyttöoikeudet
    - Tarkista ja auditoi käyttöoikeuksien käyttö säännöllisesti
    - Toteuta just-in-time -käyttöoikeudet hallinnollisiin toimintoihin

**Vastuuvapauslauseke**:  
Tämä asiakirja on käännetty käyttämällä tekoälypohjaista käännöspalvelua [Co-op Translator](https://github.com/Azure/co-op-translator). Vaikka pyrimme tarkkuuteen, huomioithan, että automaattikäännöksissä saattaa esiintyä virheitä tai epätarkkuuksia. Alkuperäinen asiakirja sen alkuperäiskielellä on virallinen lähde. Tärkeissä tiedoissa suositellaan ammattimaista ihmiskäännöstä. Emme ole vastuussa tämän käännöksen käytöstä aiheutuvista väärinymmärryksistä tai tulkinnoista.