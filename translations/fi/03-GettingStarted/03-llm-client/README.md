<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "f74887f51a69d3f255cb83d0b517c623",
  "translation_date": "2025-07-13T18:53:19+00:00",
  "source_file": "03-GettingStarted/03-llm-client/README.md",
  "language_code": "fi"
}
-->
Hienoa, seuraavaksi listataan palvelimen kyvykkyydet.

### -2 Listaa palvelimen kyvykkyydet

Yhdistämme nyt palvelimeen ja pyydämme sen kyvykkyydet: 

### -3- Muunna palvelimen kyvykkyydet LLM-työkaluiksi

Seuraava vaihe palvelimen kyvykkyyksien listaamisen jälkeen on muuntaa ne LLM:n ymmärtämään muotoon. Kun olemme tehneet tämän, voimme tarjota nämä kyvykkyydet työkaluina LLM:lle.

Hienoa, nyt olemme valmiita käsittelemään käyttäjän pyyntöjä, joten siirrytään siihen.

### -4- Käsittele käyttäjän kehotteet

Tässä koodin osassa käsittelemme käyttäjän pyyntöjä.

Hienoa, sait sen tehtyä!

## Tehtävä

Ota harjoituksesta koodi ja laajenna palvelinta lisäämällä siihen enemmän työkaluja. Luo sitten asiakas LLM:llä, kuten harjoituksessa, ja testaa sitä erilaisilla kehotteilla varmistaaksesi, että kaikki palvelimen työkalut kutsutaan dynaamisesti. Tällä tavalla rakennettu asiakas tarjoaa loppukäyttäjälle erinomaisen käyttökokemuksen, koska he voivat käyttää kehotteita tarkkojen asiakaskomentojen sijaan eivätkä huomaa, että MCP-palvelinta kutsutaan.

## Ratkaisu

[Solution](/03-GettingStarted/03-llm-client/solution/README.md)

## Tärkeimmät opit

- LLM:n lisääminen asiakkaaseen tarjoaa paremman tavan käyttäjille olla vuorovaikutuksessa MCP-palvelinten kanssa.
- MCP-palvelimen vastaus täytyy muuntaa LLM:n ymmärtämään muotoon.

## Esimerkit

- [Java-laskin](../samples/java/calculator/README.md)
- [.Net-laskin](../../../../03-GettingStarted/samples/csharp)
- [JavaScript-laskin](../samples/javascript/README.md)
- [TypeScript-laskin](../samples/typescript/README.md)
- [Python-laskin](../../../../03-GettingStarted/samples/python)

## Lisäresurssit

## Mitä seuraavaksi

- Seuraavaksi: [Palvelimen käyttäminen Visual Studio Codella](../04-vscode/README.md)

**Vastuuvapauslauseke**:  
Tämä asiakirja on käännetty käyttämällä tekoälypohjaista käännöspalvelua [Co-op Translator](https://github.com/Azure/co-op-translator). Vaikka pyrimme tarkkuuteen, huomioithan, että automaattikäännöksissä saattaa esiintyä virheitä tai epätarkkuuksia. Alkuperäistä asiakirjaa sen alkuperäiskielellä tulee pitää virallisena lähteenä. Tärkeissä asioissa suositellaan ammattimaista ihmiskäännöstä. Emme ole vastuussa tämän käännöksen käytöstä aiheutuvista väärinymmärryksistä tai tulkinnoista.