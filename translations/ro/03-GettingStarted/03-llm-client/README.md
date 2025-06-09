<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "9d80e2a99a9aea8d8226253e6baf4c8c",
  "translation_date": "2025-06-06T18:46:22+00:00",
  "source_file": "03-GettingStarted/03-llm-client/README.md",
  "language_code": "ro"
}
-->
Groza, pentru următorul nostru pas, să listăm capabilitățile serverului.

### -2 Listarea capabilităților serverului

Acum ne vom conecta la server și vom cere capabilitățile acestuia:

### -3- Convertirea capabilităților serverului în unelte pentru LLM

Următorul pas după listarea capabilităților serverului este să le convertim într-un format pe care LLM îl înțelege. Odată ce facem asta, putem oferi aceste capabilități ca unelte pentru LLM-ul nostru.

Groza, acum suntem pregătiți să gestionăm cererile utilizatorilor, așa că să abordăm acest lucru.

### -4- Gestionarea cererii promptului utilizatorului

În această parte a codului, vom gestiona cererile utilizatorilor.

Groza, ai reușit!

## Tema

Ia codul din exercițiu și extinde serverul cu câteva unelte suplimentare. Apoi creează un client cu un LLM, așa cum în exercițiu, și testează-l cu diferite prompturi pentru a te asigura că toate uneltele serverului sunt apelate dinamic. Această modalitate de a construi un client înseamnă că utilizatorul final va avea o experiență excelentă, deoarece poate folosi prompturi în loc de comenzi exacte ale clientului și va fi complet independent de orice server MCP apelat.

## Soluție

[Solution](/03-GettingStarted/03-llm-client/solution/README.md)

## Concluzii importante

- Adăugarea unui LLM la clientul tău oferă o modalitate mai bună pentru utilizatori de a interacționa cu serverele MCP.
- Trebuie să convertești răspunsul serverului MCP într-un format pe care LLM îl poate înțelege.

## Exemple

- [Java Calculator](../samples/java/calculator/README.md)
- [.Net Calculator](../../../../03-GettingStarted/samples/csharp)
- [JavaScript Calculator](../samples/javascript/README.md)
- [TypeScript Calculator](../samples/typescript/README.md)
- [Python Calculator](../../../../03-GettingStarted/samples/python)

## Resurse suplimentare

## Ce urmează

- Următorul pas: [Consumarea unui server folosind Visual Studio Code](/03-GettingStarted/04-vscode/README.md)

**Declinare a responsabilității**:  
Acest document a fost tradus folosind serviciul de traducere AI [Co-op Translator](https://github.com/Azure/co-op-translator). Deși ne străduim pentru acuratețe, vă rugăm să rețineți că traducerile automate pot conține erori sau inexactități. Documentul original, în limba sa nativă, trebuie considerat sursa autoritară. Pentru informații critice, se recomandă traducerea profesională realizată de un specialist uman. Nu ne asumăm răspunderea pentru eventualele neînțelegeri sau interpretări greșite rezultate din utilizarea acestei traduceri.