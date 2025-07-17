<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "b59b477037dc1dd6b1740a0420f3be14",
  "translation_date": "2025-07-17T08:45:33+00:00",
  "source_file": "02-Security/mcp-security-controls-2025.md",
  "language_code": "fi"
}
-->
# Latest MCP Security Controls - Heinäkuu 2025 Päivitys

Model Context Protocolin (MCP) kehittyessä turvallisuus pysyy keskeisenä huomion kohteena. Tässä dokumentissa esitellään uusimmat turvallisuusohjaimet ja parhaat käytännöt MCP:n turvalliseen toteuttamiseen heinäkuussa 2025.

## Todennus ja valtuutus

### OAuth 2.0 -valtuutuksen delegointituki

Viimeaikaiset päivitykset MCP-spesifikaatioon mahdollistavat MCP-palvelimien delegoida käyttäjien todennuksen ulkoisille palveluille, kuten Microsoft Entra ID:lle. Tämä parantaa merkittävästi turvallisuutta seuraavasti:

1. **Mukautetun todennuksen toteutuksen poistaminen**: Vähentää räätälöidyn todennuskoodin turvallisuusvirheiden riskiä  
2. **Hyödynnetään vakiintuneita identiteetin tarjoajia**: Saatavilla yritystason turvallisuusominaisuudet  
3. **Identiteetin hallinnan keskittäminen**: Käyttäjien elinkaaren hallinta ja pääsynvalvonta helpottuvat  

## Tokenin läpiviennin estäminen

MCP Authorization Specification kieltää nimenomaisesti tokenien läpiviennin estääkseen turvallisuusohjainten kiertämisen ja vastuukysymykset.

### Keskeiset vaatimukset

1. **MCP-palvelimet EIVÄT SAA hyväksyä palvelimilleen myöntämättömiä tokeneita**: Varmista, että kaikissa tokeneissa on oikea audience-claim  
2. **Toteuta asianmukainen tokenin validointi**: Tarkista myöntäjä, audience, vanhentuminen ja allekirjoitus  
3. **Käytä erillistä tokenin myöntämistä**: Myönnä uudet tokenit alaspäin suuntautuville palveluille sen sijaan, että läpäisisit olemassa olevia tokeneita  

## Turvallinen istunnon hallinta

Estääksesi istunnon kaappauksen ja kiinnityshyökkäykset, ota käyttöön seuraavat ohjaimet:

1. **Käytä turvallisia, ei-deterministisiä istuntotunnuksia**: Luodaan kryptografisesti turvallisilla satunnaislukugeneraattoreilla  
2. **Sidota istunnot käyttäjäidentiteettiin**: Yhdistä istuntotunnukset käyttäjäkohtaisiin tietoihin  
3. **Toteuta asianmukainen istunnon kierto**: Todennuksen muutosten tai oikeuksien korotuksen jälkeen  
4. **Aseta sopivat istunnon aikakatkaisut**: Tasapainota turvallisuus ja käyttökokemus  

## Työkalujen suorituksen eristäminen

Estääksesi sivuttaisliikkeet ja rajoittaaksesi mahdollisia kompromisseja:

1. **Eristä työkalujen suoritustilat**: Käytä kontteja tai erillisiä prosesseja  
2. **Aseta resurssirajoituksia**: Estä resurssien loppumiseen tähtäävät hyökkäykset  
3. **Toteuta vähimmän oikeuden periaate**: Myönnä vain tarvittavat oikeudet  
4. **Valvo suorituksen malleja**: Havaitse poikkeava käyttäytyminen  

## Työkalumäärittelyjen suojaus

Estääksesi työkalujen myrkyttämisen:

1. **Varmista työkalumäärittelyt ennen käyttöä**: Tarkista haitalliset ohjeet tai sopimattomat kuviot  
2. **Käytä eheystarkistusta**: Hashaa tai allekirjoita työkalumäärittelyt luvattomien muutosten havaitsemiseksi  
3. **Toteuta muutosten valvonta**: Hälytä odottamattomista muutoksista työkalun metatietoihin  
4. **Versioi työkalumäärittelyt**: Seuraa muutoksia ja mahdollista paluu tarvittaessa  

Nämä ohjaimet yhdessä muodostavat vahvan turvallisuusaseman MCP-toteutuksille, vastaten tekoälypohjaisten järjestelmien ainutlaatuisiin haasteisiin samalla kun ylläpidetään perinteisiä vahvoja turvallisuuskäytäntöjä.

**Vastuuvapauslauseke**:  
Tämä asiakirja on käännetty käyttämällä tekoälypohjaista käännöspalvelua [Co-op Translator](https://github.com/Azure/co-op-translator). Vaikka pyrimme tarkkuuteen, huomioithan, että automaattikäännöksissä saattaa esiintyä virheitä tai epätarkkuuksia. Alkuperäistä asiakirjaa sen alkuperäiskielellä tulee pitää virallisena lähteenä. Tärkeissä asioissa suositellaan ammattimaista ihmiskäännöstä. Emme ole vastuussa tämän käännöksen käytöstä aiheutuvista väärinymmärryksistä tai tulkinnoista.