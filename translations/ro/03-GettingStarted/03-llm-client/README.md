<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "904b689eda5a68cbafe656d53f9787c7",
  "translation_date": "2025-06-17T18:52:56+00:00",
  "source_file": "03-GettingStarted/03-llm-client/README.md",
  "language_code": "ro"
}
-->
Groza, pentru următorul pas, să listăm capabilitățile serverului.

### -2 Listarea capabilităților serverului

Acum ne vom conecta la server și îi vom cere capabilitățile: 

### -3- Convertirea capabilităților serverului în unelte pentru LLM

Următorul pas după listarea capabilităților serverului este să le convertim într-un format pe care LLM îl poate înțelege. Odată ce facem asta, putem furniza aceste capabilități ca unelte pentru LLM-ul nostru.

Groza, acum suntem pregătiți să gestionăm cererile utilizatorilor, așa că să trecem la asta.

### -4- Gestionarea cererii de prompt a utilizatorului

În această parte a codului, vom gestiona cererile utilizatorilor.

Groza, ai reușit!

## Tema

Ia codul din exercițiu și extinde serverul cu mai multe unelte. Apoi creează un client cu un LLM, așa cum ai făcut în exercițiu, și testează-l cu diferite prompturi pentru a te asigura că toate uneltele serverului sunt apelate dinamic. Această metodă de construire a unui client asigură o experiență excelentă pentru utilizatorul final, deoarece acesta poate folosi prompturi în loc de comenzi exacte ale clientului și nu trebuie să știe nimic despre apelarea unui server MCP.

## Soluție

[Solution](/03-GettingStarted/03-llm-client/solution/README.md)

## Concluzii importante

- Adăugarea unui LLM la clientul tău oferă o modalitate mai bună pentru utilizatori de a interacționa cu serverele MCP.
- Trebuie să convertești răspunsul serverului MCP într-un format pe care LLM îl poate înțelege.

## Exemple

- [Calculator Java](../samples/java/calculator/README.md)
- [Calculator .Net](../../../../03-GettingStarted/samples/csharp)
- [Calculator JavaScript](../samples/javascript/README.md)
- [Calculator TypeScript](../samples/typescript/README.md)
- [Calculator Python](../../../../03-GettingStarted/samples/python)

## Resurse suplimentare

## Ce urmează

- Următor: [Consumarea unui server folosind Visual Studio Code](/03-GettingStarted/04-vscode/README.md)

**Declinare de responsabilitate**:  
Acest document a fost tradus folosind serviciul de traducere AI [Co-op Translator](https://github.com/Azure/co-op-translator). Deși ne străduim pentru acuratețe, vă rugăm să rețineți că traducerile automate pot conține erori sau inexactități. Documentul original în limba sa nativă trebuie considerat sursa autoritară. Pentru informații critice, se recomandă traducerea profesională realizată de un traducător uman. Nu ne asumăm responsabilitatea pentru eventualele neînțelegeri sau interpretări greșite rezultate din utilizarea acestei traduceri.