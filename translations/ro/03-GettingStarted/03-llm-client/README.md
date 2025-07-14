<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "f74887f51a69d3f255cb83d0b517c623",
  "translation_date": "2025-07-13T18:56:03+00:00",
  "source_file": "03-GettingStarted/03-llm-client/README.md",
  "language_code": "ro"
}
-->
Groove, pentru pasul următor, să listăm capabilitățile serverului.

### -2 Listarea capabilităților serverului

Acum ne vom conecta la server și îi vom cere capabilitățile: 

### -3- Convertirea capabilităților serverului în unelte pentru LLM

Următorul pas după listarea capabilităților serverului este să le convertim într-un format pe care LLM îl înțelege. Odată ce facem asta, putem oferi aceste capabilități ca unelte pentru LLM-ul nostru.

Groove, acum suntem pregătiți să gestionăm cererile utilizatorilor, așa că să trecem la asta.

### -4- Gestionarea cererii de prompt a utilizatorului

În această parte a codului, vom gestiona cererile utilizatorilor.

Groove, ai reușit!

## Tema

Ia codul din exercițiu și extinde serverul cu mai multe unelte. Apoi creează un client cu un LLM, ca în exercițiu, și testează-l cu diferite prompturi pentru a te asigura că toate uneltele serverului sunt apelate dinamic. Această metodă de construire a unui client înseamnă că utilizatorul final va avea o experiență excelentă, deoarece poate folosi prompturi, în loc de comenzi exacte ale clientului, și nu va fi conștient de apelarea vreunui server MCP.

## Soluție

[Solution](/03-GettingStarted/03-llm-client/solution/README.md)

## Aspecte cheie

- Adăugarea unui LLM la client oferă o modalitate mai bună pentru utilizatori de a interacționa cu serverele MCP.
- Trebuie să convertești răspunsul serverului MCP într-un format pe care LLM îl poate înțelege.

## Exemple

- [Calculator Java](../samples/java/calculator/README.md)
- [Calculator .Net](../../../../03-GettingStarted/samples/csharp)
- [Calculator JavaScript](../samples/javascript/README.md)
- [Calculator TypeScript](../samples/typescript/README.md)
- [Calculator Python](../../../../03-GettingStarted/samples/python)

## Resurse suplimentare

## Ce urmează

- Următorul pas: [Consumarea unui server folosind Visual Studio Code](../04-vscode/README.md)

**Declinare de responsabilitate**:  
Acest document a fost tradus folosind serviciul de traducere AI [Co-op Translator](https://github.com/Azure/co-op-translator). Deși ne străduim pentru acuratețe, vă rugăm să rețineți că traducerile automate pot conține erori sau inexactități. Documentul original în limba sa nativă trebuie considerat sursa autorizată. Pentru informații critice, se recomandă traducerea profesională realizată de un specialist uman. Nu ne asumăm răspunderea pentru eventualele neînțelegeri sau interpretări greșite rezultate din utilizarea acestei traduceri.