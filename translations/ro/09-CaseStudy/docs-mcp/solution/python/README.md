<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "a05fb941810e539147fec53aaadbb6fd",
  "translation_date": "2025-07-14T06:44:01+00:00",
  "source_file": "09-CaseStudy/docs-mcp/solution/python/README.md",
  "language_code": "ro"
}
-->
# Generator de Plan de Studiu cu Chainlit & Microsoft Learn Docs MCP

## Cerințe preliminare

- Python 3.8 sau versiune superioară  
- pip (managerul de pachete Python)  
- Acces la internet pentru conectarea la serverul Microsoft Learn Docs MCP  

## Instalare

1. Clonează acest depozit sau descarcă fișierele proiectului.  
2. Instalează dependențele necesare:  

   ```bash
   pip install -r requirements.txt
   ```

## Utilizare

### Scenariul 1: Interogare simplă către Docs MCP  
Un client în linie de comandă care se conectează la serverul Docs MCP, trimite o interogare și afișează rezultatul.

1. Rulează scriptul:  
   ```bash
   python scenario1.py
   ```  
2. Introdu întrebarea ta despre documentație la prompt.

### Scenariul 2: Generator de Plan de Studiu (aplicație web Chainlit)  
O interfață web (folosind Chainlit) care permite utilizatorilor să genereze un plan de studiu personalizat, săptămână cu săptămână, pentru orice subiect tehnic.

1. Pornește aplicația Chainlit:  
   ```bash
   chainlit run scenario2.py
   ```  
2. Deschide URL-ul local afișat în terminal (de exemplu, http://localhost:8000) în browserul tău.  
3. În fereastra de chat, introdu subiectul de studiu și numărul de săptămâni pentru care vrei să studiezi (de exemplu, „certificare AI-900, 8 săptămâni”).  
4. Aplicația va răspunde cu un plan de studiu săptămânal, incluzând linkuri către documentația relevantă Microsoft Learn.

**Variabile de mediu necesare:**  

Pentru a folosi Scenariul 2 (aplicația web Chainlit cu Azure OpenAI), trebuie să setezi următoarele variabile de mediu într-un fișier `.env` în directorul `python`:  

```
AZURE_OPENAI_CHAT_DEPLOYMENT_NAME=
AZURE_OPENAI_API_KEY=
AZURE_OPENAI_ENDPOINT=
AZURE_OPENAI_API_VERSION=
```  

Completează aceste valori cu detaliile resursei tale Azure OpenAI înainte de a rula aplicația.

> **Tip:** Poți să-ți implementezi cu ușurință propriile modele folosind [Azure AI Foundry](https://ai.azure.com/).

### Scenariul 3: Documentație în editor cu server MCP în VS Code

În loc să schimbi taburile din browser pentru a căuta documentație, poți aduce Microsoft Learn Docs direct în VS Code folosind serverul MCP. Astfel poți:  
- Căuta și citi documentația în VS Code fără să părăsești mediul de programare.  
- Referenția documentația și insera linkuri direct în fișiere README sau cursuri.  
- Folosi GitHub Copilot și MCP împreună pentru un flux de lucru AI integrat și eficient.

**Exemple de utilizare:**  
- Adaugă rapid linkuri de referință într-un README în timp ce scrii documentația unui curs sau proiect.  
- Folosește Copilot pentru generare de cod și MCP pentru a găsi și cita instant documentația relevantă.  
- Rămâi concentrat în editor și crește-ți productivitatea.

> [!IMPORTANT]  
> Asigură-te că ai o configurație validă [`mcp.json`](../../../../../../09-CaseStudy/docs-mcp/solution/scenario3/mcp.json) în spațiul tău de lucru (locația este `.vscode/mcp.json`).

## De ce Chainlit pentru Scenariul 2?

Chainlit este un framework modern open-source pentru construirea aplicațiilor web conversaționale. Facilitează crearea de interfețe de chat care se conectează la servicii backend precum serverul Microsoft Learn Docs MCP. Acest proiect folosește Chainlit pentru a oferi o modalitate simplă și interactivă de a genera planuri de studiu personalizate în timp real. Prin utilizarea Chainlit, poți construi și lansa rapid instrumente bazate pe chat care îmbunătățesc productivitatea și procesul de învățare.

## Ce face această aplicație

Această aplicație permite utilizatorilor să creeze un plan de studiu personalizat introducând pur și simplu un subiect și o durată. Aplicația analizează inputul, interoghează serverul Microsoft Learn Docs MCP pentru conținut relevant și organizează rezultatele într-un plan structurat, săptămână cu săptămână. Recomandările pentru fiecare săptămână sunt afișate în chat, facilitând urmărirea progresului. Integrarea asigură accesul la cele mai noi și relevante resurse de învățare.

## Exemple de interogări

Încearcă aceste interogări în fereastra de chat pentru a vedea cum răspunde aplicația:

- `certificare AI-900, 8 săptămâni`  
- `Învață Azure Functions, 4 săptămâni`  
- `Azure DevOps, 6 săptămâni`  
- `Inginerie de date pe Azure, 10 săptămâni`  
- `Fundamente de securitate Microsoft, 5 săptămâni`  
- `Power Platform, 7 săptămâni`  
- `Servicii Azure AI, 12 săptămâni`  
- `Arhitectură cloud, 9 săptămâni`

Aceste exemple arată flexibilitatea aplicației pentru diferite obiective și perioade de învățare.

## Referințe

- [Documentația Chainlit](https://docs.chainlit.io/)  
- [Documentația MCP](https://github.com/MicrosoftDocs/mcp)

**Declinare de responsabilitate**:  
Acest document a fost tradus folosind serviciul de traducere AI [Co-op Translator](https://github.com/Azure/co-op-translator). Deși ne străduim pentru acuratețe, vă rugăm să rețineți că traducerile automate pot conține erori sau inexactități. Documentul original în limba sa nativă trebuie considerat sursa autorizată. Pentru informații critice, se recomandă traducerea profesională realizată de un specialist uman. Nu ne asumăm răspunderea pentru eventualele neînțelegeri sau interpretări greșite rezultate din utilizarea acestei traduceri.