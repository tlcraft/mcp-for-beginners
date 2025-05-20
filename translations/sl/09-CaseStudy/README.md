<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "4d3415b9d2bf58bc69be07f945a69e07",
  "translation_date": "2025-05-20T23:45:14+00:00",
  "source_file": "09-CaseStudy/README.md",
  "language_code": "sl"
}
-->
# Case Study: Azure AI Travel Agents – Reference Implementation

## Overview

[Azure AI Travel Agents](https://github.com/Azure-Samples/azure-ai-travel-agents) je celovita referenčna rešitev, ki jo je razvil Microsoft in prikazuje, kako zgraditi večagentno aplikacijo za načrtovanje potovanj, ki jo poganja umetna inteligenca, z uporabo Model Context Protocol (MCP), Azure OpenAI in Azure AI Search. Ta projekt prikazuje najboljše prakse za usklajevanje več AI agentov, integracijo podatkov podjetja in zagotavljanje varne, razširljive platforme za resnične scenarije.

## Ključne lastnosti
- **Večagentno usklajevanje:** Uporablja MCP za koordinacijo specializiranih agentov (npr. agenti za lete, hotele in itinerarje), ki sodelujejo pri zahtevnih nalogah načrtovanja potovanj.
- **Integracija podatkov podjetja:** Povezuje se z Azure AI Search in drugimi viri podatkov podjetja, da zagotovi ažurne in relevantne informacije za priporočila glede potovanj.
- **Varnostna in skalabilna arhitektura:** Izrablja Azure storitve za avtentikacijo, avtorizacijo in skalabilno namestitev, sledijoč najboljšim varnostnim praksam podjetij.
- **Razširljiva orodja:** Implementira ponovno uporabna MCP orodja in predloge pozivov, kar omogoča hitro prilagajanje novim področjem ali poslovnim zahtevam.
- **Uporabniška izkušnja:** Nudi pogovorni vmesnik, preko katerega uporabniki komunicirajo s potovalnimi agenti, ki jih poganja Azure OpenAI in MCP.

## Arhitektura
![Architecture](https://raw.githubusercontent.com/Azure-Samples/azure-ai-travel-agents/main/docs/ai-travel-agents-architecture-diagram.png)

### Opis arhitekturnega diagrama

Rešitev Azure AI Travel Agents je zasnovana za modularnost, skalabilnost in varno integracijo več AI agentov ter virov podatkov podjetja. Glavne komponente in tok podatkov so naslednji:

- **Uporabniški vmesnik:** Uporabniki komunicirajo s sistemom preko pogovornega UI (kot je spletni klepet ali Teams bot), ki pošilja uporabniške poizvedbe in prejema priporočila za potovanja.
- **MCP Server:** Deluje kot osrednji usklajevalec, sprejema uporabniški vhod, upravlja kontekst in usklajuje dejanja specializiranih agentov (npr. FlightAgent, HotelAgent, ItineraryAgent) preko Model Context Protocol.
- **AI Agenti:** Vsak agent je odgovoren za specifično področje (leti, hoteli, itinerariji) in je implementiran kot MCP orodje. Agenti uporabljajo predloge pozivov in logiko za obdelavo zahtev in generiranje odgovorov.
- **Azure OpenAI Service:** Nudi napredno razumevanje in generiranje naravnega jezika, kar omogoča agentom interpretacijo uporabniških namenov in ustvarjanje pogovornih odgovorov.
- **Azure AI Search & podatki podjetja:** Agenti poizvedujejo Azure AI Search in druge vire podatkov podjetja za pridobivanje ažurnih informacij o letih, hotelih in možnostih potovanja.
- **Avtentikacija in varnost:** Integrira se z Microsoft Entra ID za varno avtentikacijo in uporablja načelo najmanjših privilegijev za dostop do vseh virov.
- **Namestitev:** Zasnovano za namestitev na Azure Container Apps, kar zagotavlja skalabilnost, nadzor in operativno učinkovitost.

Ta arhitektura omogoča nemoteno usklajevanje več AI agentov, varno integracijo podatkov podjetja in robustno, razširljivo platformo za gradnjo AI rešitev, prilagojenih posameznim področjem.

## Korak za korakom razlaga arhitekturnega diagrama
Predstavljajte si, da načrtujete veliko potovanje in imate ekipo strokovnih pomočnikov, ki vam pomagajo pri vsakem detajlu. Sistem Azure AI Travel Agents deluje podobno, uporablja različne dele (kot člane ekipe), ki imajo vsak svojo specializirano nalogo. Tako se vse poveže:

### Uporabniški vmesnik (UI):
To je kot recepcija vašega potovalnega agenta. Tukaj vi (uporabnik) zastavite vprašanja ali oddate zahteve, na primer "Najdi mi let za Pariz." To je lahko klepetalno okno na spletni strani ali aplikacija za sporočanje.

### MCP Server (koordinator):
MCP Server je kot vodja, ki posluša vašo zahtevo na recepciji in odloči, kateri specialist naj obravnava posamezen del. Spremlja vaš pogovor in skrbi, da vse poteka gladko.

### AI Agenti (specializirani pomočniki):
Vsak agent je strokovnjak za določeno področje – eden pozna vse o letih, drugi o hotelih, tretji pa o načrtovanju itinerarja. Ko zahtevate potovanje, MCP Server pošlje vašo zahtevo pravemu agentu ali agentom. Ti uporabijo svoje znanje in orodja, da najdejo najboljše možnosti za vas.

### Azure OpenAI Service (jezikovni strokovnjak):
To je kot imeti jezikovnega strokovnjaka, ki natančno razume, kaj sprašujete, ne glede na način, kako to izrazite. Pomaga agentom razumeti vaše zahteve in odgovoriti v naravnem, pogovornem jeziku.

### Azure AI Search & podatki podjetja (informacijska knjižnica):
Predstavljajte si veliko, ažurno knjižnico z vsemi najnovejšimi informacijami o potovanjih – urniki letov, razpoložljivost hotelov in več. Agenti preiskujejo to knjižnico, da vam zagotovijo najbolj točne odgovore.

### Avtentikacija in varnost (varnostnik):
Tako kot varnostnik preverja, kdo lahko vstopi v določena območja, ta del zagotavlja, da imajo dostop le pooblaščene osebe in agenti do občutljivih informacij. Varuje vaše podatke in zasebnost.

### Namestitev na Azure Container Apps (stavba):
Vsi ti pomočniki in orodja delujejo skupaj znotraj varne, skalabilne stavbe (oblaka). To pomeni, da sistem lahko hkrati obvladuje veliko uporabnikov in je vedno na voljo, ko ga potrebujete.

## Kako vse skupaj deluje:

Najprej zastavite vprašanje na recepciji (UI).
Vodja (MCP Server) ugotovi, kateri specialist (agent) vam lahko pomaga.
Specialist uporabi jezikovnega strokovnjaka (OpenAI), da razume vašo zahtevo, in knjižnico (AI Search), da najde najboljši odgovor.
Varnostnik (Avtentikacija) poskrbi, da je vse varno.
Vse to poteka znotraj zanesljive, skalabilne stavbe (Azure Container Apps), da je vaša izkušnja gladka in varna.
Ta timsko delo omogoča sistemu, da vam hitro in varno pomaga načrtovati potovanje, kot bi to počela ekipa strokovnih potovalnih agentov v sodobni pisarni!

## Tehnična implementacija
- **MCP Server:** Gostuje osnovno logiko usklajevanja, izpostavlja orodja agentov in upravlja kontekst za večstopenjske delovne procese načrtovanja potovanj.
- **Agenti:** Vsak agent (npr. FlightAgent, HotelAgent) je implementiran kot MCP orodje s svojimi predlogami pozivov in logiko.
- **Integracija Azure:** Uporablja Azure OpenAI za razumevanje naravnega jezika in Azure AI Search za pridobivanje podatkov.
- **Varnost:** Integrira se z Microsoft Entra ID za avtentikacijo in uporablja načelo najmanjših privilegijev za dostop do vseh virov.
- **Namestitev:** Podpira namestitev na Azure Container Apps za skalabilnost in operativno učinkovitost.

## Rezultati in vpliv
- Prikazuje, kako se MCP lahko uporablja za usklajevanje več AI agentov v resničnem, produkcijskem okolju.
- Pospešuje razvoj rešitev z zagotavljanjem ponovno uporabnih vzorcev za koordinacijo agentov, integracijo podatkov in varno namestitev.
- Služi kot načrt za gradnjo AI aplikacij, prilagojenih posameznim področjem, z uporabo MCP in Azure storitev.

## Reference
- [Azure AI Travel Agents GitHub Repository](https://github.com/Azure-Samples/azure-ai-travel-agents)
- [Azure OpenAI Service](https://azure.microsoft.com/en-us/products/ai-services/openai-service/)
- [Azure AI Search](https://azure.microsoft.com/en-us/products/ai-services/ai-search/)
- [Model Context Protocol (MCP)](https://modelcontextprotocol.io/)

**Omejitev odgovornosti**:  
Ta dokument je bil preveden z uporabo AI prevajalske storitve [Co-op Translator](https://github.com/Azure/co-op-translator). Čeprav si prizadevamo za natančnost, vas opozarjamo, da avtomatizirani prevodi lahko vsebujejo napake ali netočnosti. Izvirni dokument v njegovem izvirnem jeziku velja za avtoritativni vir. Za pomembne informacije priporočamo strokovni človeški prevod. Nismo odgovorni za morebitna nesporazume ali napačne interpretacije, ki izhajajo iz uporabe tega prevoda.