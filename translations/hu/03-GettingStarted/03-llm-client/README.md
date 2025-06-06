<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "9d80e2a99a9aea8d8226253e6baf4c8c",
  "translation_date": "2025-06-06T18:42:35+00:00",
  "source_file": "03-GettingStarted/03-llm-client/README.md",
  "language_code": "hu"
}
-->
Nagyszerű, a következő lépésként soroljuk fel a szerver képességeit.

### -2 Szerver képességeinek listázása

Most csatlakozunk a szerverhez, és lekérjük a képességeit:

### -3- Szerver képességek átalakítása LLM eszközökké

A következő lépés a szerver képességeinek listázása után, hogy olyan formátumba alakítsuk őket, amit az LLM megért. Miután ez megtörtént, ezeket a képességeket eszközként adhatjuk át az LLM-nek.

Nagyszerű, most már készen állunk arra, hogy kezeljük a felhasználói kéréseket, nézzük meg ezt a következő lépésben.

### -4- Felhasználói prompt kérés kezelése

Ebben a kódrészletben a felhasználói kérések kezelését valósítjuk meg.

Nagyszerű, sikerült!

## Feladat

Vedd át a gyakorlatból származó kódot, és építs ki a szervert további eszközökkel. Ezután hozz létre egy klienst LLM-mel, ahogy a gyakorlatban láttad, és teszteld különböző promptokkal, hogy megbizonyosodj arról, hogy a szerver összes eszköze dinamikusan meghívódik. Ez a kliensépítési mód nagyszerű felhasználói élményt nyújt, hiszen a végfelhasználó promptokat használhat, nem kell pontos kliensparancsokat ismernie, és nem kell tudnia az MCP szerver hívásáról.

## Megoldás

[Solution](/03-GettingStarted/03-llm-client/solution/README.md)

## Főbb tanulságok

- Az LLM hozzáadása a klienshez jobb interakciós lehetőséget biztosít a felhasználóknak az MCP szerverekkel.
- Az MCP szerver válaszát olyan formátumba kell alakítani, amit az LLM megért.

## Minták

- [Java számológép](../samples/java/calculator/README.md)
- [.Net számológép](../../../../03-GettingStarted/samples/csharp)
- [JavaScript számológép](../samples/javascript/README.md)
- [TypeScript számológép](../samples/typescript/README.md)
- [Python számológép](../../../../03-GettingStarted/samples/python)

## További források

## Mi következik

- Következő: [Szerver használata Visual Studio Code-dal](/03-GettingStarted/04-vscode/README.md)

**Jogi nyilatkozat**:  
Ez a dokumentum az AI fordító szolgáltatás [Co-op Translator](https://github.com/Azure/co-op-translator) segítségével készült. Bár igyekszünk a pontosságra, kérjük, vegye figyelembe, hogy az automatikus fordítások hibákat vagy pontatlanságokat tartalmazhatnak. Az eredeti dokumentum az anyanyelvén tekintendő hivatalos forrásnak. Fontos információk esetén szakmai, emberi fordítást javaslunk. Nem vállalunk felelősséget az ebből a fordításból eredő félreértésekért vagy téves értelmezésekért.