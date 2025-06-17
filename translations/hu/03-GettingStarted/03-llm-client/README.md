<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "904b689eda5a68cbafe656d53f9787c7",
  "translation_date": "2025-06-17T18:52:14+00:00",
  "source_file": "03-GettingStarted/03-llm-client/README.md",
  "language_code": "hu"
}
-->
Nagyszerű, a következő lépésként listázzuk ki a szerver képességeit.

### -2 Szerver képességeinek listázása

Most csatlakozunk a szerverhez, és lekérdezzük a képességeit:

### -3- Szerver képességek átalakítása LLM eszközökké

A következő lépés a szerver képességeinek listázása után, hogy átalakítsuk őket az LLM által értelmezhető formátumba. Ha ez megvan, ezeket a képességeket eszközként adhatjuk át az LLM-nek.

Nagyszerű, most készen állunk arra, hogy kezeljük a felhasználói kéréseket, tehát nézzük meg ezt a következő lépésben.

### -4- Felhasználói prompt kérés kezelése

Ebben a kódrészletben a felhasználói kéréseket fogjuk kezelni.

Nagyszerű, sikerült!

## Feladat

Vedd át a gyakorlatban írt kódot, és bővítsd a szervert további eszközökkel. Ezután hozz létre egy klienst LLM-mel, ahogy a gyakorlatban láttad, és teszteld különböző promptokkal, hogy megbizonyosodj róla, minden szervereszköz dinamikusan meghívásra kerül. Ez a kliensépítési mód nagyszerű felhasználói élményt biztosít, hiszen a végfelhasználó promptokat használhat a pontos kliensparancsok helyett, és nem kell tudnia arról, hogy egy MCP szerver hívódik meg.

## Megoldás

[Solution](/03-GettingStarted/03-llm-client/solution/README.md)

## Főbb tanulságok

- Az LLM hozzáadása a klienshez jobb interakciós lehetőséget biztosít a felhasználóknak az MCP szerverekkel.
- Az MCP szerver válaszát olyan formátumba kell alakítani, amit az LLM megért.

## Példák

- [Java számológép](../samples/java/calculator/README.md)
- [.Net számológép](../../../../03-GettingStarted/samples/csharp)
- [JavaScript számológép](../samples/javascript/README.md)
- [TypeScript számológép](../samples/typescript/README.md)
- [Python számológép](../../../../03-GettingStarted/samples/python)

## További források

## Mi következik

- Következő: [Szerver használata Visual Studio Code-dal](/03-GettingStarted/04-vscode/README.md)

**Jogi nyilatkozat**:  
Ezt a dokumentumot az AI fordító szolgáltatás [Co-op Translator](https://github.com/Azure/co-op-translator) segítségével fordítottuk le. Bár a pontosságra törekszünk, kérjük, vegye figyelembe, hogy az automatikus fordítások tartalmazhatnak hibákat vagy pontatlanságokat. Az eredeti dokumentum az anyanyelvén tekintendő hiteles forrásnak. Fontos információk esetén szakmai, emberi fordítást javaslunk. Nem vállalunk felelősséget az ebből eredő félreértésekért vagy félreértelmezésekért.