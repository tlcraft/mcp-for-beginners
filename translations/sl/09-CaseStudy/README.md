<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "6c11b6162171abc895ed75d1e0f368a3",
  "translation_date": "2025-06-20T19:11:38+00:00",
  "source_file": "09-CaseStudy/README.md",
  "language_code": "sl"
}
-->
# MCP v praksi: študije primerov iz resničnega sveta

Model Context Protocol (MCP) spreminja način, kako AI aplikacije sodelujejo s podatki, orodji in storitvami. Ta razdelek predstavlja študije primerov iz resničnega sveta, ki prikazujejo praktične uporabe MCP v različnih poslovnih okoljih.

## Pregled

V tem razdelku so prikazani konkretni primeri implementacij MCP, ki poudarjajo, kako organizacije izkoriščajo ta protokol za reševanje zapletenih poslovnih izzivov. Z analizo teh študij primerov boste pridobili vpogled v vsestranskost, skalabilnost in praktične koristi MCP v resničnih situacijah.

## Ključni cilji učenja

Z raziskovanjem teh študij primerov boste:

- razumeli, kako se MCP lahko uporabi za reševanje specifičnih poslovnih problemov  
- spoznali različne vzorce integracije in arhitekturne pristope  
- prepoznali najboljše prakse za implementacijo MCP v poslovnih okoljih  
- pridobili vpogled v izzive in rešitve, s katerimi se srečujejo pri resničnih implementacijah  
- prepoznali priložnosti za uporabo podobnih vzorcev v svojih projektih  

## Izpostavljene študije primerov

### 1. [Azure AI Travel Agents – referenčna implementacija](./travelagentsample.md)

Ta študija primera preučuje Microsoftovo celovito referenčno rešitev, ki prikazuje, kako z uporabo MCP, Azure OpenAI in Azure AI Search zgraditi večagentno, AI-podprto aplikacijo za načrtovanje potovanj. Projekt prikazuje:

- večagentno orkestracijo prek MCP  
- integracijo poslovnih podatkov z Azure AI Search  
- varno in skalabilno arhitekturo z uporabo Azure storitev  
- razširljiva orodja z večkratno uporabo komponent MCP  
- pogovorno uporabniško izkušnjo, ki jo poganja Azure OpenAI  

Arhitekturni in izvedbeni podrobnosti nudijo dragocene vpoglede v gradnjo kompleksnih večagentnih sistemov z MCP kot slojem za koordinacijo.

### 2. [Posodabljanje Azure DevOps elementov iz podatkov YouTube](./UpdateADOItemsFromYT.md)

Ta študija primera prikazuje praktično uporabo MCP za avtomatizacijo delovnih procesov. Pokaže, kako je mogoče z orodji MCP:

- pridobivati podatke z spletnih platform (YouTube)  
- posodabljati delovne elemente v sistemih Azure DevOps  
- ustvarjati ponovljive avtomatizirane delovne tokove  
- integrirati podatke med različnimi sistemi  

Ta primer prikazuje, kako lahko tudi razmeroma preproste implementacije MCP prinesejo znatne izboljšave učinkovitosti z avtomatizacijo rutinskih opravil in izboljšanjem konsistence podatkov med sistemi.

## Zaključek

Te študije primerov poudarjajo vsestranskost in praktične uporabe Model Context Protocol v resničnih situacijah. Od kompleksnih večagentnih sistemov do ciljno usmerjenih avtomatiziranih delovnih tokov, MCP nudi standardiziran način povezovanja AI sistemov z orodji in podatki, ki jih potrebujejo za ustvarjanje vrednosti.

S preučevanjem teh implementacij lahko pridobite vpogled v arhitekturne vzorce, strategije izvedbe in najboljše prakse, ki jih lahko uporabite v svojih MCP projektih. Primeri dokazujejo, da MCP ni zgolj teoretični okvir, temveč praktična rešitev za resnične poslovne izzive.

## Dodatni viri

- [Azure AI Travel Agents GitHub repozitorij](https://github.com/Azure-Samples/azure-ai-travel-agents)  
- [Azure DevOps MCP Tool](https://github.com/microsoft/azure-devops-mcp)  
- [Playwright MCP Tool](https://github.com/microsoft/playwright-mcp)  
- [MCP Community Examples](https://github.com/microsoft/mcp)

**Opozorilo**:  
Ta dokument je bil preveden z uporabo AI prevajalske storitve [Co-op Translator](https://github.com/Azure/co-op-translator). Čeprav si prizadevamo za natančnost, vas opozarjamo, da avtomatizirani prevodi lahko vsebujejo napake ali netočnosti. Izvirni dokument v njegovem izvirnem jeziku velja za avtoritativni vir. Za pomembne informacije priporočamo strokovni človeški prevod. Nismo odgovorni za morebitne nesporazume ali napačne interpretacije, ki izhajajo iz uporabe tega prevoda.