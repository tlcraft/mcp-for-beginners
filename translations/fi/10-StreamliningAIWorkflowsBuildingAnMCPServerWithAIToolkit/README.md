<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "787440926586cd064b0899fd1c514f52",
  "translation_date": "2025-07-14T07:09:22+00:00",
  "source_file": "10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/README.md",
  "language_code": "fi"
}
-->
# Tehosta tekoälytyönkulkuja: MCP-palvelimen rakentaminen AI Toolkitin avulla

[![MCP Version](https://img.shields.io/badge/MCP-1.9.3-blue.svg)](https://modelcontextprotocol.io/)
[![Python](https://img.shields.io/badge/Python-3.10+-green.svg)](https://python.org)
[![VS Code](https://img.shields.io/badge/VS%20Code-Latest-orange.svg)](https://code.visualstudio.com/)

![logo](../../../translated_images/logo.ec93918ec338dadde1715c8aaf118079e0ed0502e9efdfcc84d6a0f4a9a70ae8.fi.png)

## 🎯 Yleiskatsaus

Tervetuloa **Model Context Protocol (MCP) -työpajaan**! Tämä kattava käytännön työpaja yhdistää kaksi huipputeknologiaa mullistaakseen tekoälysovelluskehityksen:

- **🔗 Model Context Protocol (MCP)**: Avoin standardi saumattomaan tekoälytyökalujen integrointiin
- **🛠️ AI Toolkit for Visual Studio Code (AITK)**: Microsoftin tehokas tekoälykehityksen laajennus

### 🎓 Mitä opit

Työpajan päätteeksi hallitset älykkäiden sovellusten rakentamisen, jotka yhdistävät tekoälymallit todellisiin työkaluihin ja palveluihin. Automaattisesta testauksesta räätälöityihin API-integraatioihin saat käytännön taitoja monimutkaisten liiketoimintaongelmien ratkaisemiseen.

## 🏗️ Teknologiapino

### 🔌 Model Context Protocol (MCP)

MCP on **"USB-C tekoälylle"** – universaali standardi, joka yhdistää tekoälymallit ulkoisiin työkaluihin ja tietolähteisiin.

**✨ Keskeiset ominaisuudet:**
- 🔄 **Standardoitu integraatio**: Yhtenäinen rajapinta tekoälytyökalujen liittämiseen
- 🏛️ **Joustava arkkitehtuuri**: Paikalliset ja etäpalvelimet stdio/SSE-siirrolla
- 🧰 **Rikas ekosysteemi**: Työkaluja, kehotteita ja resursseja yhdessä protokollassa
- 🔒 **Yrityskäyttöön valmis**: Sisäänrakennettu turvallisuus ja luotettavuus

**🎯 Miksi MCP on tärkeä:**
Aivan kuten USB-C poisti kaoskaapelit, MCP poistaa tekoälyintegraatioiden monimutkaisuuden. Yksi protokolla, rajattomat mahdollisuudet.

### 🤖 AI Toolkit for Visual Studio Code (AITK)

Microsoftin lippulaivalaajennus, joka muuttaa VS Coden tekoälyvoimaksi.

**🚀 Keskeiset ominaisuudet:**
- 📦 **Mallikatalogi**: Pääsy malleihin Azure AI:sta, GitHubista, Hugging Facesta, Ollamasta
- ⚡ **Paikallinen inferenssi**: ONNX-optimoitu CPU/GPU/NPU-suoritus
- 🏗️ **Agent Builder**: Visuaalinen tekoälyagenttien kehitys MCP-integraatiolla
- 🎭 **Monimodaalinen**: Teksti-, kuva- ja rakenteellisen tulosteen tuki

**💡 Kehityksen edut:**
- Nollakonfiguraatiolla mallien käyttöönotto
- Visuaalinen kehotteiden suunnittelu
- Reaaliaikainen testausympäristö
- Saumaton MCP-palvelinintegraatio

## 📚 Oppimispolku

### [🚀 Moduuli 1: AI Toolkitin perusteet](./lab1/README.md)
**Kesto**: 15 minuuttia
- 🛠️ AI Toolkitin asennus ja konfigurointi VS Codeen
- 🗂️ Mallikatalogin tutkiminen (yli 100 mallia GitHubista, ONNX:stä, OpenAI:sta, Anthropicista, Googlesta)
- 🎮 Interaktiivisen testialustan hallinta reaaliaikaiseen mallien testaamiseen
- 🤖 Ensimmäisen tekoälyagentin rakentaminen Agent Builderilla
- 📊 Mallin suorituskyvyn arviointi sisäänrakennetuilla mittareilla (F1, relevanssi, samankaltaisuus, johdonmukaisuus)
- ⚡ Eräajon ja monimodaalisen tuen opiskelu

**🎯 Oppimistavoite**: Luo toimiva tekoälyagentti ja ymmärrä AITK:n ominaisuudet kokonaisvaltaisesti

### [🌐 Moduuli 2: MCP ja AI Toolkitin perusteet](./lab2/README.md)
**Kesto**: 20 minuuttia
- 🧠 Model Context Protocolin (MCP) arkkitehtuurin ja konseptien hallinta
- 🌐 Microsoftin MCP-palvelinympäristön tutkiminen
- 🤖 Selainautomaattisen agentin rakentaminen Playwright MCP -palvelimella
- 🔧 MCP-palvelinten integrointi AI Toolkitin Agent Builderiin
- 📊 MCP-työkalujen konfigurointi ja testaus agenteissa
- 🚀 MCP-tehostettujen agenttien vienti ja käyttöönotto tuotantoon

**🎯 Oppimistavoite**: Ota käyttöön tekoälyagentti, joka hyödyntää ulkoisia työkaluja MCP:n kautta

### [🔧 Moduuli 3: Edistynyt MCP-kehitys AI Toolkitin kanssa](./lab3/README.md)
**Kesto**: 20 minuuttia
- 💻 Räätälöityjen MCP-palvelinten luominen AI Toolkitilla
- 🐍 Uusimman MCP Python SDK:n (v1.9.3) konfigurointi ja käyttö
- 🔍 MCP Inspectorin käyttöönotto ja hyödyntäminen virheenkorjauksessa
- 🛠️ Sään MCP-palvelimen rakentaminen ammattimaisilla debuggausprosesseilla
- 🧪 MCP-palvelinten virheenkorjaus sekä Agent Builderissa että Inspectorissa

**🎯 Oppimistavoite**: Kehitä ja debuggaa räätälöityjä MCP-palvelimia nykyaikaisilla työkaluilla

### [🐙 Moduuli 4: Käytännön MCP-kehitys – Räätälöity GitHub Clone -palvelin](./lab4/README.md)
**Kesto**: 30 minuuttia
- 🏗️ Rakennetaan todellisen maailman GitHub Clone MCP -palvelin kehitystyönkulkuja varten
- 🔄 Älykkään repositorion kloonaus validoinnilla ja virheenkäsittelyllä
- 📁 Älykäs hakemiston hallinta ja VS Code -integraatio
- 🤖 GitHub Copilot Agent Mode räätälöidyillä MCP-työkaluilla
- 🛡️ Tuotantovalmius, luotettavuus ja monialustainen yhteensopivuus

**🎯 Oppimistavoite**: Ota käyttöön tuotantovalmiiksi hiottu MCP-palvelin, joka tehostaa aitoja kehitystyönkulkuja

## 💡 Käytännön sovellukset ja vaikutus

### 🏢 Yrityskäyttötapaukset

#### 🔄 DevOps-automaatio
Muunna kehitystyönkulku älykkäällä automaatiolla:
- **Älykäs repositorionhallinta**: Tekoälypohjainen koodikatselmointi ja yhdistämispäätökset
- **Älykäs CI/CD**: Automaattinen putkiston optimointi koodimuutosten perusteella
- **Ongelmanluokittelu**: Automaattinen bugien luokittelu ja tehtävien jakaminen

#### 🧪 Laadunvarmistuksen vallankumous
Nosta testaus uudelle tasolle tekoälyllä:
- **Älykäs testien generointi**: Laajat testipaketit automaattisesti
- **Visuaalinen regressiotestaus**: Tekoälyllä UI-muutosten havaitseminen
- **Suorituskyvyn seuranta**: Ennakoiva ongelmien tunnistus ja korjaus

#### 📊 Datan käsittelyn älykkyys
Rakenna älykkäämpiä datan prosessointityönkulkuja:
- **Mukautuvat ETL-prosessit**: Itseoptimoituvat datamuunnokset
- **Poikkeamien havaitseminen**: Reaaliaikainen datan laadun valvonta
- **Älykäs reititys**: Tehokas datavirtojen hallinta

#### 🎧 Asiakaskokemuksen parantaminen
Luo poikkeuksellisia asiakaskohtaamisia:
- **Kontekstin huomioiva tuki**: Tekoälyagentit pääsyllä asiakashistoriaan
- **Ennakoiva ongelmanratkaisu**: Ennustava asiakaspalvelu
- **Monikanavainen integraatio**: Yhtenäinen tekoälykokemus eri alustoilla

## 🛠️ Esivaatimukset ja asennus

### 💻 Järjestelmävaatimukset

| Komponentti           | Vaatimus               | Huomautukset           |
|----------------------|------------------------|-----------------------|
| **Käyttöjärjestelmä** | Windows 10+, macOS 10.15+, Linux | Mikä tahansa nykyaikainen OS |
| **Visual Studio Code**| Uusin vakaa versio     | Pakollinen AITK:lle    |
| **Node.js**           | v18.0+ ja npm          | MCP-palvelinkehitykseen |
| **Python**            | 3.10+                  | Valinnainen Python MCP -palvelimille |
| **Muisti**            | Vähintään 8GB RAM      | 16GB suositeltu paikallisille malleille |

### 🔧 Kehitysympäristö

#### Suositellut VS Code -laajennukset
- **AI Toolkit** (ms-windows-ai-studio.windows-ai-studio)
- **Python** (ms-python.python)
- **Python Debugger** (ms-python.debugpy)
- **GitHub Copilot** (GitHub.copilot) – Valinnainen, mutta hyödyllinen

#### Valinnaiset työkalut
- **uv**: Moderni Python-pakettien hallinta
- **MCP Inspector**: Visuaalinen debuggaustyökalu MCP-palvelimille
- **Playwright**: Verkkoselaimen automaatiota varten

## 🎖️ Oppimistulokset ja sertifiointipolku

### 🏆 Taitojen hallinnan tarkistuslista

Tämän työpajan suorittamalla saavutat hallinnan seuraavilla osa-alueilla:

#### 🎯 Keskeiset osaamiset
- [ ] **MCP-protokollan hallinta**: Syvällinen arkkitehtuurin ja toteutusmallien ymmärrys
- [ ] **AITK-osaaminen**: Asiantuntijatasoinen AI Toolkitin käyttö nopeaan kehitykseen
- [ ] **Räätälöity palvelinkehitys**: MCP-palvelinten rakentaminen, käyttöönotto ja ylläpito tuotannossa
- [ ] **Työkalujen integrointi**: Saumaton tekoälyn yhdistäminen olemassa oleviin kehitystyönkulkuihin
- [ ] **Ongelmanratkaisu**: Opittujen taitojen soveltaminen todellisiin liiketoimintaongelmiin

#### 🔧 Tekninen osaaminen
- [ ] AI Toolkitin asennus ja konfigurointi VS Codessa
- [ ] Räätälöityjen MCP-palvelinten suunnittelu ja toteutus
- [ ] GitHub-mallien integrointi MCP-arkkitehtuuriin
- [ ] Automaattisten testityönkulkujen rakentaminen Playwrightilla
- [ ] Tekoälyagenttien käyttöönotto tuotantoon
- [ ] MCP-palvelinten virheenkorjaus ja suorituskyvyn optimointi

#### 🚀 Edistyneet taidot
- [ ] Yritystason tekoälyintegraatioiden arkkitehtuurin suunnittelu
- [ ] Turvallisuusparhaiden käytäntöjen toteutus tekoälysovelluksissa
- [ ] Skaalautuvien MCP-palvelinarkkitehtuurien suunnittelu
- [ ] Räätälöityjen työkaluketjujen luominen erityisaloille
- [ ] Mentorointi tekoälyyn perustuvassa kehityksessä

## 📖 Lisäresurssit
- [MCP Specification](https://modelcontextprotocol.io/docs)
- [AI Toolkit GitHub Repository](https://github.com/microsoft/vscode-ai-toolkit)
- [Sample MCP Servers Collection](https://github.com/modelcontextprotocol/servers)
- [Best Practices Guide](https://modelcontextprotocol.io/docs/best-practices)

---

**🚀 Valmiina mullistamaan tekoälykehityksesi?**

Rakennetaan yhdessä älykkäiden sovellusten tulevaisuus MCP:n ja AI Toolkitin avulla!

**Vastuuvapauslauseke**:  
Tämä asiakirja on käännetty käyttämällä tekoälypohjaista käännöspalvelua [Co-op Translator](https://github.com/Azure/co-op-translator). Vaikka pyrimme tarkkuuteen, huomioithan, että automaattikäännöksissä saattaa esiintyä virheitä tai epätarkkuuksia. Alkuperäistä asiakirjaa sen alkuperäiskielellä tulee pitää virallisena lähteenä. Tärkeissä asioissa suositellaan ammattimaista ihmiskäännöstä. Emme ole vastuussa tämän käännöksen käytöstä aiheutuvista väärinymmärryksistä tai tulkinnoista.