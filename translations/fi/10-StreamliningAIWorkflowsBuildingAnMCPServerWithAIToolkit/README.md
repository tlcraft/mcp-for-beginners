<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "787440926586cd064b0899fd1c514f52",
  "translation_date": "2025-06-10T04:59:44+00:00",
  "source_file": "10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/README.md",
  "language_code": "fi"
}
-->
# Sujuvoita AI-työnkulkuja: MCP-palvelimen rakentaminen AI Toolkitin avulla

[![MCP Version](https://img.shields.io/badge/MCP-1.9.3-blue.svg)](https://modelcontextprotocol.io/)
[![Python](https://img.shields.io/badge/Python-3.10+-green.svg)](https://python.org)
[![VS Code](https://img.shields.io/badge/VS%20Code-Latest-orange.svg)](https://code.visualstudio.com/)

![logo](../../../translated_images/logo.ec93918ec338dadde1715c8aaf118079e0ed0502e9efdfcc84d6a0f4a9a70ae8.fi.png)

## 🎯 Yleiskatsaus

Tervetuloa **Model Context Protocol (MCP) -työpajaan**! Tämä kattava käytännön työpaja yhdistää kaksi huipputeknologiaa mullistaakseen AI-sovelluskehityksen:

- **🔗 Model Context Protocol (MCP)**: Avoin standardi saumattomaan AI-työkalujen integrointiin
- **🛠️ AI Toolkit for Visual Studio Code (AITK)**: Microsoftin tehokas AI-kehityslaajennus

### 🎓 Mitä opit

Työpajan päätteeksi hallitset älykkäiden sovellusten rakentamisen, jotka yhdistävät AI-mallit todellisiin työkaluihin ja palveluihin. Automaattisesta testauksesta räätälöityihin API-integraatioihin saat käytännön taitoja monimutkaisten liiketoimintaongelmien ratkaisemiseksi.

## 🏗️ Teknologiakokonaisuus

### 🔌 Model Context Protocol (MCP)

MCP on **"USB-C AI:lle"** – yleinen standardi, joka yhdistää AI-mallit ulkoisiin työkaluihin ja tietolähteisiin.

**✨ Keskeiset ominaisuudet:**
- 🔄 **Standardoitu integraatio**: Yhtenäinen rajapinta AI-työkalujen liittämiseen
- 🏛️ **Joustava arkkitehtuuri**: Paikalliset ja etäpalvelimet stdio/SSE-siirrolla
- 🧰 **Monipuolinen ekosysteemi**: Työkaluja, kehotteita ja resursseja yhdessä protokollassa
- 🔒 **Yritystason valmius**: Sisäänrakennettu turvallisuus ja luotettavuus

**🎯 Miksi MCP on tärkeä:**
Aivan kuten USB-C poisti kaoskaapelit, MCP poistaa AI-integraatioiden monimutkaisuuden. Yksi protokolla, loputtomat mahdollisuudet.

### 🤖 AI Toolkit for Visual Studio Code (AITK)

Microsoftin lippulaivalaajennus, joka muuttaa VS Coden AI-tehokkaaksi työkaluksi.

**🚀 Keskeiset kyvyt:**
- 📦 **Malliluettelo**: Pääsy malleihin Azure AI:sta, GitHubista, Hugging Facesta, Ollamasta
- ⚡ **Paikallinen inferenssi**: ONNX-optimoitu CPU/GPU/NPU-suoritus
- 🏗️ **Agent Builder**: Visuaalinen AI-agenttien kehitys MCP-integraatiolla
- 🎭 **Monimodaalinen**: Tekstin, kuvan ja rakenteellisen tulosteen tuki

**💡 Kehityksen edut:**
- Nollakonfiguraatiolla mallien käyttöönotto
- Visuaalinen kehotteiden suunnittelu
- Reaaliaikainen testausympäristö
- Saumaton MCP-palvelinintegraatio

## 📚 Oppimispolku

### [🚀 Moduuli 1: AI Toolkitin perusteet](./lab1/README.md)
**Kesto**: 15 minuuttia
- 🛠️ AI Toolkitin asennus ja konfigurointi VS Codeen
- 🗂️ Tutustu Malliluetteloon (yli 100 mallia GitHubista, ONNX:stä, OpenAI:sta, Anthropicista, Googlesta)
- 🎮 Hallitse interaktiivinen testialusta reaaliaikaiseen mallien kokeiluun
- 🤖 Rakenna ensimmäinen AI-agenttisi Agent Builderilla
- 📊 Arvioi mallin suorituskykyä sisäänrakennetuilla mittareilla (F1, merkityksellisyys, samankaltaisuus, johdonmukaisuus)
- ⚡ Opi eräajosta ja monimodaalisesta tuesta

**🎯 Oppimistavoite**: Luo toimiva AI-agentti ja ymmärrä kattavasti AITK:n ominaisuudet

### [🌐 Moduuli 2: MCP ja AI Toolkitin perusteet](./lab2/README.md)
**Kesto**: 20 minuuttia
- 🧠 Hallitse Model Context Protocolin (MCP) arkkitehtuuri ja käsitteet
- 🌐 Tutustu Microsoftin MCP-palvelinympäristöön
- 🤖 Rakenna selainautomaattinen agentti Playwright MCP -palvelimella
- 🔧 Integroi MCP-palvelimet AI Toolkitin Agent Builderiin
- 📊 Konfiguroi ja testaa MCP-työkaluja agenteissasi
- 🚀 Vie ja ota käyttöön MCP-työkaluilla varustetut agentit tuotantoon

**🎯 Oppimistavoite**: Ota käyttöön AI-agentti, joka hyödyntää ulkoisia työkaluja MCP:n kautta

### [🔧 Moduuli 3: Edistynyt MCP-kehitys AI Toolkitin kanssa](./lab3/README.md)
**Kesto**: 20 minuuttia
- 💻 Luo räätälöityjä MCP-palvelimia AI Toolkitilla
- 🐍 Konfiguroi ja käytä uusinta MCP Python SDK:ta (v1.9.3)
- 🔍 Ota MCP Inspector käyttöön virheenkorjaukseen
- 🛠️ Rakenna Sää MCP -palvelin ammattimaisilla virheenkorjausprosesseilla
- 🧪 Virheenkorjaa MCP-palvelimia sekä Agent Builderissa että Inspectorissa

**🎯 Oppimistavoite**: Kehitä ja virheenkorjaa räätälöityjä MCP-palvelimia nykyaikaisilla työkaluilla

### [🐙 Moduuli 4: Käytännön MCP-kehitys – Räätälöity GitHub Clone -palvelin](./lab4/README.md)
**Kesto**: 30 minuuttia
- 🏗️ Rakenna todellisen maailman GitHub Clone MCP -palvelin kehitystyönkuluille
- 🔄 Toteuta älykäs repositorion kloonaus validoinnilla ja virheenkäsittelyllä
- 📁 Luo älykäs hakemiston hallinta ja VS Code -integraatio
- 🤖 Käytä GitHub Copilot Agent Modea räätälöityjen MCP-työkalujen kanssa
- 🛡️ Varmista tuotantovalmius, luotettavuus ja monialustainen yhteensopivuus

**🎯 Oppimistavoite**: Ota käyttöön tuotantovalmiiksi tarkoitettu MCP-palvelin, joka tehostaa aitoja kehitystyönkulkuja

## 💡 Käytännön sovellukset ja vaikutus

### 🏢 Yrityskäyttötapaukset

#### 🔄 DevOps-automaatio
Muunna kehitystyönkulku älykkäällä automaatiolla:
- **Älykäs repositorion hallinta**: AI-avusteinen koodikatselmointi ja yhdistämispäätökset
- **Älykäs CI/CD**: Automaattinen putkiston optimointi koodimuutosten perusteella
- **Ongelmatriage**: Automaattinen bugiluokittelu ja tehtävien jakaminen

#### 🧪 Laadunvarmistuksen vallankumous
Nosta testaus AI-avusteisella automaatiolla:
- **Älykäs testien generointi**: Laajat testipaketit automaattisesti
- **Visuaalinen regressiotestaus**: AI-avusteinen käyttöliittymän muutosten tunnistus
- **Suorituskyvyn seuranta**: Ennakoiva ongelmien havaitseminen ja korjaus

#### 📊 Tiedonputken älykkyys
Rakenna älykkäämpiä tiedonkäsittelytyönkulkuja:
- **Sopeutuva ETL**: Itseoptimoituvat tiedonmuunnokset
- **Poikkeamien havaitseminen**: Reaaliaikainen tiedon laadun seuranta
- **Älykäs reititys**: Älykäs tiedonvirran hallinta

#### 🎧 Asiakaskokemuksen parantaminen
Luo poikkeuksellisia asiakaskohtaamisia:
- **Kontekstin huomioiva tuki**: AI-agentit, joilla pääsy asiakashistoriaan
- **Ennakoiva ongelmanratkaisu**: Ennustava asiakaspalvelu
- **Monikanavainen integraatio**: Yhtenäinen AI-kokemus eri alustoilla

## 🛠️ Vaatimukset ja asennus

### 💻 Järjestelmävaatimukset

| Komponentti           | Vaatimus                | Huomautukset               |
|----------------------|-------------------------|----------------------------|
| **Käyttöjärjestelmä** | Windows 10+, macOS 10.15+, Linux | Mikä tahansa nykyaikainen OS |
| **Visual Studio Code**| Viimeisin vakaa versio  | Tarvitaan AITK:lle         |
| **Node.js**           | v18.0+ ja npm           | MCP-palvelimen kehitykseen |
| **Python**            | 3.10+                   | Valinnainen Python MCP -palvelimiin |
| **Muisti**            | Vähintään 8GB RAM       | 16GB suositellaan paikallisille malleille |

### 🔧 Kehitysympäristö

#### Suositellut VS Code -laajennukset
- **AI Toolkit** (ms-windows-ai-studio.windows-ai-studio)
- **Python** (ms-python.python)
- **Python Debugger** (ms-python.debugpy)
- **GitHub Copilot** (GitHub.copilot) – Valinnainen mutta hyödyllinen

#### Valinnaiset työkalut
- **uv**: Moderni Python-pakettien hallinta
- **MCP Inspector**: Visuaalinen virheenkorjaustyökalu MCP-palvelimille
- **Playwright**: Verkkoselaimen automaatiota varten

## 🎖️ Oppimistulokset ja sertifiointipolku

### 🏆 Taitojen hallinnan tarkistuslista

Työpajan suorittamalla hallitset:

#### 🎯 Keskeiset osaamisalueet
- [ ] **MCP-protokollan hallinta**: Syvällinen arkkitehtuurin ja toteutusmallien ymmärrys
- [ ] **AITK-osaaminen**: Asiantuntijatason käyttö AI Toolkitilla nopeaan kehitykseen
- [ ] **Räätälöity palvelinkehitys**: MCP-palvelimien rakentaminen, käyttöönotto ja ylläpito tuotannossa
- [ ] **Työkalujen integraation taito**: AI:n saumaton liittäminen olemassa oleviin kehitystyönkulkuihin
- [ ] **Ongelmanratkaisu**: Opittujen taitojen soveltaminen todellisiin liiketoimintaongelmiin

#### 🔧 Tekninen osaaminen
- [ ] AI Toolkitin asennus ja konfigurointi VS Codessa
- [ ] Räätälöityjen MCP-palvelimien suunnittelu ja toteutus
- [ ] GitHub-mallien integrointi MCP-arkkitehtuuriin
- [ ] Automaattisten testityönkulkujen rakentaminen Playwrightilla
- [ ] AI-agenttien käyttöönotto tuotannossa
- [ ] MCP-palvelimen suorituskyvyn virheenkorjaus ja optimointi

#### 🚀 Edistyneet kyvyt
- [ ] Suuryritystason AI-integraatioiden arkkitehtuurin suunnittelu
- [ ] Turvallisuusparhaiden käytäntöjen toteutus AI-sovelluksissa
- [ ] Skaalautuvien MCP-palvelinarkkitehtuurien suunnittelu
- [ ] Räätälöityjen työkaluketjujen luominen erityisaloille
- [ ] Mentorointi AI-native-kehityksessä

## 📖 Lisäresurssit
- [MCP Specification](https://modelcontextprotocol.io/docs)
- [AI Toolkit GitHub Repository](https://github.com/microsoft/vscode-ai-toolkit)
- [Sample MCP Servers Collection](https://github.com/modelcontextprotocol/servers)
- [Best Practices Guide](https://modelcontextprotocol.io/docs/best-practices)

---

**🚀 Valmiina mullistamaan AI-kehitystyönkulusi?**

Rakennetaan yhdessä älykkäiden sovellusten tulevaisuus MCP:n ja AI Toolkitin avulla!

**Vastuuvapauslauseke**:  
Tämä asiakirja on käännetty käyttämällä tekoälypohjaista käännöspalvelua [Co-op Translator](https://github.com/Azure/co-op-translator). Pyrimme tarkkuuteen, mutta huomioithan, että automaattiset käännökset voivat sisältää virheitä tai epätarkkuuksia. Alkuperäinen asiakirja sen alkuperäiskielellä tulee pitää auktoriteettina. Tärkeissä asioissa suositellaan ammattimaista ihmiskäännöstä. Emme ole vastuussa tämän käännöksen käytöstä aiheutuvista väärinymmärryksistä tai tulkinnoista.