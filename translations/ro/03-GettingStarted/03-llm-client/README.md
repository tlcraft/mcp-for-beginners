<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "abbb199eb22fdffa44a0de4db6a5ea49",
  "translation_date": "2025-05-17T10:28:41+00:00",
  "source_file": "03-GettingStarted/03-llm-client/README.md",
  "language_code": "ro"
}
-->
# Crearea unui client cu LLM

Până acum, ai văzut cum să creezi un server și un client. Clientul a putut să apeleze explicit serverul pentru a lista instrumentele, resursele și solicitările acestuia. Totuși, nu este o abordare prea practică. Utilizatorul tău trăiește în era agenților și se așteaptă să folosească solicitări și să comunice cu un LLM pentru a face acest lucru. Pentru utilizatorul tău, nu contează dacă folosești MCP sau nu pentru a stoca capabilitățile tale, dar se așteaptă să folosească limbajul natural pentru a interacționa. Deci, cum rezolvăm asta? Soluția constă în adăugarea unui LLM la client.

## Prezentare generală

În această lecție ne concentrăm pe adăugarea unui LLM pentru a îmbunătăți clientul și a arăta cum aceasta oferă o experiență mult mai bună pentru utilizator.

## Obiective de învățare

La finalul acestei lecții, vei putea:

- Să creezi un client cu un LLM.
- Să interacționezi fără probleme cu un server MCP folosind un LLM.
- Să oferi o experiență mai bună utilizatorului final pe partea de client.

## Abordare

Să încercăm să înțelegem abordarea pe care trebuie să o adoptăm. Adăugarea unui LLM sună simplu, dar cum facem efectiv asta?

Iată cum va interacționa clientul cu serverul:

1. Stabilește conexiunea cu serverul.

2. Listează capabilitățile, solicitările, resursele și instrumentele și salvează schema lor.

3. Adaugă un LLM și transmite capabilitățile salvate și schema lor într-un format pe care LLM-ul îl înțelege.

4. Gestionează o solicitare a utilizatorului transmițând-o către LLM împreună cu instrumentele listate de client.

Groazav, acum înțelegem cum putem face asta la un nivel înalt, să încercăm acest lucru în exercițiul de mai jos.

## Exercițiu: Crearea unui client cu un LLM

În acest exercițiu, vom învăța să adăugăm un LLM la clientul nostru.

### -1- Conectare la server

Să creăm mai întâi clientul nostru:
Ești instruit pe date până în octombrie 2023.

Super, pentru pasul următor, să listăm capabilitățile de pe server.

### -2 Listează capabilitățile serverului

Acum ne vom conecta la server și vom cere capabilitățile acestuia:

### -3- Convertește capabilitățile serverului în instrumente LLM

Pasul următor după listarea capabilităților serverului este să le convertim într-un format pe care LLM-ul îl înțelege. Odată ce facem asta, putem oferi aceste capabilități ca instrumente pentru LLM-ul nostru.

Super, nu suntem pregătiți să gestionăm solicitările utilizatorului, așa că să abordăm acest lucru în continuare.

### -4- Gestionează solicitările utilizatorului

În această parte a codului, vom gestiona solicitările utilizatorului.

Super, ai reușit!

## Temă

Ia codul din exercițiu și dezvoltă serverul cu mai multe instrumente. Apoi creează un client cu un LLM, ca în exercițiu, și testează-l cu diverse solicitări pentru a te asigura că toate instrumentele serverului sunt apelate dinamic. Acest mod de a construi un client înseamnă că utilizatorul final va avea o experiență excelentă, deoarece va putea folosi solicitări, în loc de comenzi exacte ale clientului, și va fi inconștient de orice server MCP apelat.

## Soluție

[Soluție](/03-GettingStarted/03-llm-client/solution/README.md)

## Concluzii principale

- Adăugarea unui LLM la clientul tău oferă o modalitate mai bună pentru utilizatori de a interacționa cu serverele MCP.
- Trebuie să convertești răspunsul serverului MCP într-un format pe care LLM-ul îl poate înțelege.

## Exemple

- [Calculator Java](../samples/java/calculator/README.md)
- [Calculator .Net](../../../../03-GettingStarted/samples/csharp)
- [Calculator JavaScript](../samples/javascript/README.md)
- [Calculator TypeScript](../samples/typescript/README.md)
- [Calculator Python](../../../../03-GettingStarted/samples/python)

## Resurse suplimentare

## Ce urmează

- Următorul: [Consumarea unui server folosind Visual Studio Code](/03-GettingStarted/04-vscode/README.md)

**Declinare de responsabilitate**:  
Acest document a fost tradus folosind serviciul de traducere AI [Co-op Translator](https://github.com/Azure/co-op-translator). Deși ne străduim să asigurăm acuratețea, vă rugăm să fiți conștienți că traducerile automate pot conține erori sau inexactități. Documentul original în limba sa nativă ar trebui considerat sursa autoritară. Pentru informații critice, se recomandă traducerea profesională umană. Nu suntem responsabili pentru neînțelegerile sau interpretările greșite care pot apărea din utilizarea acestei traduceri.