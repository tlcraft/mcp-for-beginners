<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "b6b1bc868efed4cf02c52f8deada559d",
  "translation_date": "2025-05-17T17:36:48+00:00",
  "source_file": "09-CaseStudy/Readme.md",
  "language_code": "sl"
}
-->
# Študija primera: Azure AI potovalni agenti – referenčna implementacija

## Pregled

[Azure AI potovalni agenti](https://github.com/Azure-Samples/azure-ai-travel-agents) je celovita referenčna rešitev, ki jo je razvil Microsoft in prikazuje, kako zgraditi aplikacijo za načrtovanje potovanj, ki jo poganja AI, z uporabo protokola Model Context Protocol (MCP), Azure OpenAI in Azure AI Search. Ta projekt prikazuje najboljše prakse za orkestracijo več AI agentov, integracijo podatkov podjetja ter zagotavljanje varne in razširljive platforme za resnične scenarije.

## Ključne funkcije
- **Orkestracija več agentov:** Uporablja MCP za koordinacijo specializiranih agentov (npr. agentov za lete, hotele in itinerarje), ki sodelujejo pri izpolnjevanju kompleksnih nalog načrtovanja potovanj.
- **Integracija podatkov podjetja:** Povezuje se z Azure AI Search in drugimi viri podatkov podjetja za zagotavljanje aktualnih in relevantnih informacij za priporočila potovanj.
- **Varna, razširljiva arhitektura:** Izkoristi Azure storitve za avtentikacijo, avtorizacijo in razširljivo implementacijo, pri čemer sledi najboljšim praksam varnosti podjetja.
- **Razširljivo orodje:** Implementira ponovno uporabna MCP orodja in predloge za pozive, kar omogoča hitro prilagoditev novim domenam ali poslovnim zahtevam.
- **Uporabniška izkušnja:** Omogoča pogovorni vmesnik za interakcijo uporabnikov s potovalnimi agenti, ki ga poganjata Azure OpenAI in MCP.

## Arhitektura
![Arhitektura](https://github.com/Azure-Samples/azure-ai-travel-agents/blob/main/docs/ai-travel-agents-architecture-diagram.png)

### Opis diagrama arhitekture

Rešitev Azure AI potovalni agenti je zasnovana za modularnost, razširljivost in varno integracijo več AI agentov ter virov podatkov podjetja. Glavne komponente in tok podatkov so naslednji:

- **Uporabniški vmesnik:** Uporabniki komunicirajo s sistemom preko pogovornega UI (kot je spletni klepet ali Teams bot), ki pošilja uporabniške poizvedbe in prejema priporočila za potovanja.
- **MCP strežnik:** Deluje kot osrednji orkestrator, sprejema uporabniške vnose, upravlja kontekst in koordinira dejanja specializiranih agentov (npr. FlightAgent, HotelAgent, ItineraryAgent) preko protokola Model Context Protocol.
- **AI agenti:** Vsak agent je odgovoren za določeno področje (leti, hoteli, itinerarji) in je implementiran kot MCP orodje. Agenti uporabljajo predloge za pozive in logiko za obdelavo zahtev ter generiranje odgovorov.
- **Azure OpenAI storitev:** Omogoča napredno razumevanje in generiranje naravnega jezika, kar omogoča agentom interpretacijo uporabniških namenov in generiranje pogovornih odgovorov.
- **Azure AI Search & podatki podjetja:** Agenti poizvedujejo Azure AI Search in druge vire podatkov podjetja za pridobivanje aktualnih informacij o letih, hotelih in potovalnih možnostih.
- **Avtentikacija & varnost:** Integrira se z Microsoft Entra ID za varno avtentikacijo in uporablja nadzor dostopa z najmanjšimi privilegiji za vse vire.
- **Implementacija:** Zasnovano za implementacijo na Azure Container Apps, kar zagotavlja razširljivost, nadzor in operativno učinkovitost.

Ta arhitektura omogoča brezhibno orkestracijo več AI agentov, varno integracijo s podatki podjetja ter robustno, razširljivo platformo za gradnjo domen-specifičnih AI rešitev.

## Razlaga diagrama arhitekture po korakih
Predstavljajte si, da načrtujete veliko potovanje in imate ekipo strokovnih pomočnikov, ki vam pomagajo pri vsakem detajlu. Sistem Azure AI potovalni agenti deluje na podoben način, uporablja različne dele (kot člane ekipe), ki imajo vsak posebno nalogo. Tukaj je, kako se vse skupaj povezuje:

### Uporabniški vmesnik (UI):
Pomislite na to kot na sprednjo pisarno vašega potovalnega agenta. Tukaj vi (uporabnik) postavljate vprašanja ali podajate zahteve, kot je "Najdi mi let v Pariz." To bi lahko bil klepetalni okno na spletni strani ali aplikacija za sporočila.

### MCP strežnik (Koordinator):
MCP strežnik je kot upravitelj, ki posluša vašo zahtevo na sprednji pisarni in se odloči, kateri specialist naj obravnava vsak del. Spremlja vaš pogovor in zagotavlja, da vse teče gladko.

### AI agenti (Specialistični pomočniki):
Vsak agent je strokovnjak za določeno področje—eden pozna vse o letih, drugi o hotelih, tretji o načrtovanju vašega itinerarja. Ko zaprosite za potovanje, MCP strežnik pošlje vašo zahtevo pravemu agentu(-om). Ti agenti uporabljajo svoje znanje in orodja za iskanje najboljših možnosti za vas.

### Azure OpenAI storitev (Jezični strokovnjak):
To je kot imeti jezikovnega strokovnjaka, ki natančno razume, kaj sprašujete, ne glede na to, kako to oblikujete. Pomaga agentom razumeti vaše zahteve in odgovarjati v naravnem, pogovornem jeziku.

### Azure AI Search & podatki podjetja (Informacijska knjižnica):
Predstavljajte si ogromno, ažurirano knjižnico z vsemi najnovejšimi informacijami o potovanjih—urniki letov, razpoložljivost hotelov in še več. Agenti pregledujejo to knjižnico, da pridobijo najbolj natančne odgovore za vas.

### Avtentikacija & varnost (Varnostnik):
Tako kot varnostnik preverja, kdo lahko vstopi na določena območja, ta del zagotavlja, da lahko le pooblaščeni ljudje in agenti dostopajo do občutljivih informacij. Vaše podatke ohranja varne in zasebne.

### Implementacija na Azure Container Apps (Zgradba):
Vsi ti pomočniki in orodja delujejo skupaj znotraj varne, razširljive zgradbe (oblaka). To pomeni, da sistem lahko obravnava veliko uporabnikov hkrati in je vedno na voljo, ko ga potrebujete.

## Kako vse deluje skupaj:

Začnete z vprašanjem na sprednji pisarni (UI).
Upravitelj (MCP strežnik) ugotovi, kateri specialist (agent) naj vam pomaga.
Specialist uporabi jezikovnega strokovnjaka (OpenAI) za razumevanje vaše zahteve in knjižnico (AI Search) za iskanje najboljšega odgovora.
Varnostnik (Avtentikacija) zagotovi, da je vse varno.
Vse to se zgodi znotraj zanesljive, razširljive zgradbe (Azure Container Apps), tako da je vaša izkušnja gladka in varna.
Ta timsko delo omogoča sistemu, da hitro in varno pomaga pri načrtovanju vašega potovanja, tako kot ekipa strokovnih potovalnih agentov, ki sodelujejo v moderni pisarni!

## Tehnična implementacija
- **MCP strežnik:** Gosti osnovno logiko orkestracije, izpostavlja orodja agentov in upravlja kontekst za večstopenjske delovne tokove načrtovanja potovanj.
- **Agenti:** Vsak agent (npr. FlightAgent, HotelAgent) je implementiran kot MCP orodje s svojimi predlogami za pozive in logiko.
- **Integracija z Azure:** Uporablja Azure OpenAI za razumevanje naravnega jezika in Azure AI Search za pridobivanje podatkov.
- **Varnost:** Integrira se z Microsoft Entra ID za avtentikacijo in uporablja nadzor dostopa z najmanjšimi privilegiji za vse vire.
- **Implementacija:** Podpira implementacijo na Azure Container Apps za razširljivost in operativno učinkovitost.

## Rezultati in vpliv
- Prikazuje, kako se MCP lahko uporablja za orkestracijo več AI agentov v resničnem, proizvodnem scenariju.
- Pospešuje razvoj rešitev z zagotavljanjem ponovno uporabnih vzorcev za koordinacijo agentov, integracijo podatkov in varno implementacijo.
- Služi kot načrt za gradnjo domen-specifičnih aplikacij, ki jih poganja AI, z uporabo MCP in Azure storitev.

## Reference
- [Azure AI potovalni agenti GitHub repozitorij](https://github.com/Azure-Samples/azure-ai-travel-agents)
- [Azure OpenAI storitev](https://azure.microsoft.com/en-us/products/ai-services/openai-service/)
- [Azure AI Search](https://azure.microsoft.com/en-us/products/ai-services/ai-search/)
- [Model Context Protocol (MCP)](https://modelcontextprotocol.io/)

**Omejitev odgovornosti**:
Ta dokument je bil preveden z uporabo storitve AI prevajanja [Co-op Translator](https://github.com/Azure/co-op-translator). Čeprav si prizadevamo za natančnost, prosimo, upoštevajte, da lahko samodejni prevodi vsebujejo napake ali netočnosti. Izvirni dokument v njegovem maternem jeziku je treba obravnavati kot avtoritativni vir. Za kritične informacije je priporočljivo profesionalno človeško prevajanje. Ne odgovarjamo za morebitne nesporazume ali napačne razlage, ki izhajajo iz uporabe tega prevoda.