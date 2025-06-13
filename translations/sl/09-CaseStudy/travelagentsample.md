<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "4d3415b9d2bf58bc69be07f945a69e07",
  "translation_date": "2025-06-13T21:55:06+00:00",
  "source_file": "09-CaseStudy/travelagentsample.md",
  "language_code": "sl"
}
-->
# Case Study: Azure AI Travel Agents – Reference Implementation

## Overview

[Azure AI Travel Agents](https://github.com/Azure-Samples/azure-ai-travel-agents) je obsežna referenčna rešitev, ki jo je razvil Microsoft in prikazuje, kako zgraditi večagentno, z AI podprto aplikacijo za načrtovanje potovanj z uporabo Model Context Protocol (MCP), Azure OpenAI in Azure AI Search. Ta projekt prikazuje najboljše prakse za usklajevanje več AI agentov, integracijo podatkov podjetja in zagotavljanje varne, razširljive platforme za resnične scenarije.

## Ključne lastnosti
- **Usklajevanje več agentov:** Uporablja MCP za koordinacijo specializiranih agentov (npr. agent za lete, hotele in itinerarje), ki sodelujejo pri zahtevnih nalogah načrtovanja potovanj.
- **Integracija podatkov podjetja:** Povezuje se z Azure AI Search in drugimi viri podatkov podjetja, da zagotovi ažurne in relevantne informacije za priporočila potovanj.
- **Varnostna, razširljiva arhitektura:** Izkorišča Azure storitve za avtentikacijo, avtorizacijo in razširljivo uvajanje, sledijoč najboljšim praksam varnosti v podjetjih.
- **Razširljiva orodja:** Implementira ponovno uporabna MCP orodja in predloge pozivov, kar omogoča hitro prilagoditev novim področjem ali poslovnim zahtevam.
- **Uporabniška izkušnja:** Nudi pogovorni vmesnik, preko katerega uporabniki komunicirajo z agenti za potovanja, podprt z Azure OpenAI in MCP.

## Arhitektura
![Architecture](https://raw.githubusercontent.com/Azure-Samples/azure-ai-travel-agents/main/docs/ai-travel-agents-architecture-diagram.png)

### Opis arhitekturne sheme

Rešitev Azure AI Travel Agents je zasnovana modularno, skalabilno in varno za integracijo več AI agentov ter virov podatkov podjetja. Glavne komponente in tok podatkov so naslednji:

- **Uporabniški vmesnik:** Uporabniki komunicirajo s sistemom preko pogovornega UI (npr. spletni klepet ali Teams bot), ki pošilja uporabniške poizvedbe in prejema priporočila za potovanja.
- **MCP Server:** Deluje kot osrednji usklajevalec, prejema uporabniške vnose, upravlja kontekst in koordinira delo specializiranih agentov (npr. FlightAgent, HotelAgent, ItineraryAgent) preko Model Context Protocol.
- **AI Agenti:** Vsak agent je odgovoren za specifično področje (leti, hoteli, itinerariji) in je implementiran kot MCP orodje. Agenti uporabljajo predloge pozivov in logiko za obdelavo zahtev in generiranje odgovorov.
- **Azure OpenAI Service:** Omogoča napredno razumevanje in generiranje naravnega jezika, kar agentom pomaga razumeti uporabniške namene in ustvarjati pogovorne odgovore.
- **Azure AI Search & podatki podjetja:** Agenti poizvedujejo Azure AI Search in druge vire podatkov podjetja, da pridobijo ažurne informacije o letih, hotelih in možnostih potovanj.
- **Avtentikacija in varnost:** Integrira se z Microsoft Entra ID za varno avtentikacijo in uporablja pravila najmanjših privilegijev za dostop do vseh virov.
- **Uvajanje:** Namenjeno uvajanju na Azure Container Apps, kar zagotavlja skalabilnost, spremljanje in operativno učinkovitost.

Ta arhitektura omogoča nemoteno usklajevanje več AI agentov, varno integracijo podatkov podjetja ter robustno, razširljivo platformo za razvoj AI rešitev specifičnih za domeno.

## Korak za korakom pojasnilo arhitekturne sheme
Predstavljajte si, da načrtujete veliko potovanje in imate ekipo strokovnih pomočnikov, ki vam pomagajo pri vsakem detajlu. Sistem Azure AI Travel Agents deluje podobno, uporablja različne dele (kot člane ekipe), ki imajo vsak svojo specialno nalogo. Tako se vse poveže:

### Uporabniški vmesnik (UI):
To je kot recepcija vašega potovalnega agenta. Tukaj vi (uporabnik) postavite vprašanja ali zahtevke, na primer “Poišči mi let do Pariza.” Lahko je klepetalno okno na spletni strani ali sporočilna aplikacija.

### MCP Server (Koordinator):
MCP Server je kot vodja, ki posluša vašo zahtevo na recepciji in odloči, kateri specialist naj obravnava posamezen del. Sledi vašemu pogovoru in skrbi, da vse poteka gladko.

### AI Agenti (Specialistični pomočniki):
Vsak agent je strokovnjak za določeno področje – eden pozna vse o letih, drugi o hotelih, tretji pa o načrtovanju itinerarija. Ko zahtevate potovanje, MCP Server pošlje vašo zahtevo pravim agentom. Ti agenti uporabijo svoje znanje in orodja, da najdejo najboljše možnosti za vas.

### Azure OpenAI Service (Strokovnjak za jezik):
To je kot imeti jezikovnega strokovnjaka, ki razume, kaj točno sprašujete, ne glede na način izražanja. Pomaga agentom razumeti vaše zahteve in odgovoriti v naravnem, pogovornem jeziku.

### Azure AI Search & podatki podjetja (Knjižnica informacij):
Predstavljajte si ogromno, ažurno knjižnico z vsemi najnovejšimi informacijami o potovanjih – vozni redi letov, razpoložljivost hotelov in še več. Agenti preiskujejo to knjižnico, da vam zagotovijo najbolj točne odgovore.

### Avtentikacija in varnost (Varnostnik):
Kot varnostnik, ki preverja, kdo lahko vstopi v določena območja, ta del zagotavlja, da do občutljivih informacij dostopajo samo pooblaščeni uporabniki in agenti. Vaši podatki so varni in zasebni.

### Uvajanje na Azure Container Apps (Zgradba):
Vsi ti pomočniki in orodja delujejo skupaj znotraj varne, razširljive zgradbe (oblaka). To pomeni, da sistem lahko istočasno podpira veliko uporabnikov in je vedno na voljo, ko ga potrebujete.

## Kako vse skupaj deluje:

Najprej postavite vprašanje na recepciji (UI).
Vodja (MCP Server) določi, kateri specialist (agent) vam bo pomagal.
Specialist uporabi jezikovnega strokovnjaka (OpenAI), da razume vašo zahtevo, in knjižnico (AI Search), da najde najboljši odgovor.
Varnostnik (Avtentikacija) poskrbi, da je vse varno.
Vse to se dogaja v zanesljivi, razširljivi zgradbi (Azure Container Apps), zato je vaša izkušnja gladka in varna.
Ta timsko delo omogoča sistemu, da vam hitro in varno pomaga načrtovati potovanje, kot bi to počela ekipa strokovnih potovalnih agentov v sodobni pisarni!

## Tehnična implementacija
- **MCP Server:** Gosti osrednjo logiko usklajevanja, razkriva orodja agentov in upravlja kontekst za večstopenjske delovne tokove načrtovanja potovanj.
- **Agenti:** Vsak agent (npr. FlightAgent, HotelAgent) je implementiran kot MCP orodje z lastnimi predlogami pozivov in logiko.
- **Integracija Azure:** Uporablja Azure OpenAI za razumevanje naravnega jezika in Azure AI Search za pridobivanje podatkov.
- **Varnost:** Integrira se z Microsoft Entra ID za avtentikacijo in uporablja pravila najmanjših privilegijev za dostop do vseh virov.
- **Uvajanje:** Podpira uvajanje na Azure Container Apps za skalabilnost in operativno učinkovitost.

## Rezultati in vpliv
- Prikazuje, kako lahko MCP uporabimo za usklajevanje več AI agentov v realnem, produkcijskem okolju.
- Pospešuje razvoj rešitev z zagotavljanjem ponovno uporabnih vzorcev za koordinacijo agentov, integracijo podatkov in varno uvajanje.
- Služi kot načrt za gradnjo domeno-specifičnih, z AI podprtih aplikacij z uporabo MCP in Azure storitev.

## Reference
- [Azure AI Travel Agents GitHub Repository](https://github.com/Azure-Samples/azure-ai-travel-agents)
- [Azure OpenAI Service](https://azure.microsoft.com/en-us/products/ai-services/openai-service/)
- [Azure AI Search](https://azure.microsoft.com/en-us/products/ai-services/ai-search/)
- [Model Context Protocol (MCP)](https://modelcontextprotocol.io/)

**Opozorilo**:  
Ta dokument je bil preveden z uporabo AI prevajalske storitve [Co-op Translator](https://github.com/Azure/co-op-translator). Čeprav si prizadevamo za natančnost, vas prosimo, da upoštevate, da lahko avtomatizirani prevodi vsebujejo napake ali netočnosti. Izvirni dokument v njegovem izvor nem jeziku velja za avtoritativni vir. Za pomembne informacije priporočamo strokovni človeški prevod. Nismo odgovorni za morebitne nesporazume ali napačne interpretacije, ki izhajajo iz uporabe tega prevoda.