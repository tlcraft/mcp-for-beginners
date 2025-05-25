<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "abbb199eb22fdffa44a0de4db6a5ea49",
  "translation_date": "2025-05-17T10:23:28+00:00",
  "source_file": "03-GettingStarted/03-llm-client/README.md",
  "language_code": "fi"
}
-->
# Asiakkaan luominen LLM:n avulla

Tähän mennessä olet nähnyt, kuinka luodaan palvelin ja asiakas. Asiakas on pystynyt kutsumaan palvelinta eksplisiittisesti listatakseen sen työkalut, resurssit ja kehotteet. Tämä lähestymistapa ei kuitenkaan ole kovin käytännöllinen. Käyttäjäsi elää agenttien aikakaudella ja odottaa voivansa käyttää kehotteita ja kommunikoida LLM:n kanssa. Käyttäjällesi ei ole väliä, käytätkö MCP:tä kykyjesi tallentamiseen, mutta he odottavat voivansa käyttää luonnollista kieltä vuorovaikutukseen. Kuinka siis ratkaista tämä? Ratkaisu on lisätä LLM asiakkaaseen.

## Yleiskatsaus

Tässä oppitunnissa keskitymme LLM:n lisäämiseen asiakkaaseesi ja näytämme, kuinka tämä tarjoaa paljon paremman kokemuksen käyttäjällesi.

## Oppimistavoitteet

Tämän oppitunnin lopussa osaat:

- Luoda asiakkaan LLM:n avulla.
- Vuorovaikuttaa saumattomasti MCP-palvelimen kanssa LLM:n avulla.
- Tarjota paremman loppukäyttäjäkokemuksen asiakkaan puolella.

## Lähestymistapa

Yritetään ymmärtää lähestymistapa, joka meidän tulee ottaa. LLM:n lisääminen kuulostaa yksinkertaiselta, mutta miten sen oikeastaan teemme?

Näin asiakas vuorovaikuttaa palvelimen kanssa:

1. Yhteyden muodostaminen palvelimeen.

1. Kykyjen, kehotteiden, resurssien ja työkalujen listaaminen ja niiden skeeman tallentaminen.

1. LLM:n lisääminen ja tallennettujen kykyjen ja niiden skeeman välittäminen LLM:lle ymmärrettävässä muodossa.

1. Käyttäjän kehotteen käsitteleminen välittämällä se LLM:lle yhdessä asiakkaan listaamien työkalujen kanssa.

Hienoa, nyt ymmärrämme, kuinka voimme tehdä tämän korkealla tasolla, kokeillaan tätä alla olevassa harjoituksessa.

## Harjoitus: Asiakkaan luominen LLM:n avulla

Tässä harjoituksessa opimme lisäämään LLM:n asiakkaaseemme.

### -1- Yhdistä palvelimeen

Luodaan ensin asiakkaamme:
Olet koulutettu dataan lokakuuhun 2023 asti.

Hienoa, seuraavaksi listataan palvelimen kyvyt.

### -2 Listaa palvelimen kyvyt

Nyt yhdistämme palvelimeen ja kysymme sen kyvyistä.

### -3- Muunna palvelimen kyvyt LLM-työkaluiksi

Seuraava askel kykyjen listaamisen jälkeen on muuntaa ne LLM:n ymmärtämään muotoon. Kun teemme sen, voimme tarjota nämä kyvyt työkaluina LLM:lle.

Hienoa, nyt olemme valmiita käsittelemään käyttäjän pyyntöjä, joten käsitellään se seuraavaksi.

### -4- Käsittele käyttäjän kehotepyynnöt

Tässä osassa koodia käsittelemme käyttäjän pyyntöjä.

Hienoa, teit sen!

## Tehtävä

Ota koodi harjoituksesta ja rakenna palvelin lisäämällä joitain työkaluja. Sitten luo asiakas LLM:n avulla, kuten harjoituksessa, ja testaa sitä erilaisilla kehotteilla varmistaaksesi, että kaikki palvelimen työkalut kutsutaan dynaamisesti. Tällainen tapa rakentaa asiakas tarkoittaa, että loppukäyttäjällä on loistava käyttökokemus, sillä he voivat käyttää kehotteita tarkkojen asiakaskomentojen sijaan ja olla tietämättömiä MCP-palvelimen kutsumisesta.

## Ratkaisu

[Ratkaisu](/03-GettingStarted/03-llm-client/solution/README.md)

## Keskeiset Opit

- LLM:n lisääminen asiakkaaseesi tarjoaa paremman tavan käyttäjille vuorovaikuttaa MCP-palvelimien kanssa.
- Sinun täytyy muuntaa MCP-palvelimen vastaus LLM:n ymmärtämään muotoon.

## Esimerkit

- [Java-laskin](../samples/java/calculator/README.md)
- [.Net-laskin](../../../../03-GettingStarted/samples/csharp)
- [JavaScript-laskin](../samples/javascript/README.md)
- [TypeScript-laskin](../samples/typescript/README.md)
- [Python-laskin](../../../../03-GettingStarted/samples/python) 

## Lisäresurssit

## Mitä Seuraavaksi

- Seuraavaksi: [Palvelimen käyttäminen Visual Studio Codella](/03-GettingStarted/04-vscode/README.md)

**Vastuuvapauslauseke**:  
Tämä asiakirja on käännetty käyttämällä AI-käännöspalvelua [Co-op Translator](https://github.com/Azure/co-op-translator). Vaikka pyrimme tarkkuuteen, ole tietoinen siitä, että automaattiset käännökset voivat sisältää virheitä tai epätarkkuuksia. Alkuperäinen asiakirja sen alkuperäisellä kielellä tulisi pitää auktoriteettina. Kriittisen tiedon osalta suositellaan ammattimaista ihmiskäännöstä. Emme ole vastuussa väärinkäsityksistä tai virhetulkinnoista, jotka johtuvat tämän käännöksen käytöstä.