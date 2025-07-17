<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "b59b477037dc1dd6b1740a0420f3be14",
  "translation_date": "2025-07-17T13:40:16+00:00",
  "source_file": "02-Security/mcp-security-controls-2025.md",
  "language_code": "sl"
}
-->
# Najnovejši varnostni ukrepi MCP - posodobitev julij 2025

Ker se Model Context Protocol (MCP) še naprej razvija, varnost ostaja ključni dejavnik. Ta dokument povzema najnovejše varnostne ukrepe in najboljše prakse za varno implementacijo MCP od julija 2025.

## Avtentikacija in avtorizacija

### Podpora za delegacijo OAuth 2.0

Nedavne posodobitve specifikacije MCP zdaj omogočajo MCP strežnikom, da delegirajo avtentikacijo uporabnikov na zunanje storitve, kot je Microsoft Entra ID. To bistveno izboljša varnost z:

1. **Odpravo lastnih implementacij avtentikacije**: Zmanjšuje tveganje varnostnih ranljivosti v lastni kodi za avtentikacijo  
2. **Izkoriščanjem uveljavljenih ponudnikov identitete**: Izkoristek varnostnih funkcij na ravni podjetij  
3. **Centralizacijo upravljanja identitet**: Poenostavi upravljanje življenjskega cikla uporabnikov in nadzor dostopa  

## Preprečevanje posredovanja žetonov

Specifikacija MCP Authorization izrecno prepoveduje posredovanje žetonov, da prepreči obhod varnostnih ukrepov in težave z odgovornostjo.

### Ključne zahteve

1. **MCP strežniki NE SMEJO sprejemati žetonov, ki niso izdani zanje**: Preverite, da imajo vsi žetoni pravilen audience claim  
2. **Izvedite pravilno validacijo žetonov**: Preverite izdajatelja, audience, potek veljavnosti in podpis  
3. **Uporabite ločeno izdajo žetonov**: Izdajte nove žetone za nadaljnje storitve namesto posredovanja obstoječih  

## Varnostno upravljanje sej

Za preprečevanje prevzema sej in napadov fiksacije sej izvedite naslednje ukrepe:

1. **Uporabljajte varne, nedeterministične ID-je sej**: Generirane s kriptografsko varnimi generatorji naključnih števil  
2. **Povežite seje z identiteto uporabnika**: Združite ID-je sej z informacijami, specifičnimi za uporabnika  
3. **Izvedite pravilno rotacijo sej**: Po spremembah avtentikacije ali povišanju privilegijev  
4. **Nastavite ustrezne časovne omejitve sej**: Uravnotežite varnost in uporabniško izkušnjo  

## Izolacija izvajanja orodij

Za preprečevanje lateralnega premikanja in omejitev morebitnih kompromisov:

1. **Izolirajte okolja za izvajanje orodij**: Uporabite kontejnere ali ločene procese  
2. **Uporabite omejitve virov**: Preprečite napade izčrpavanja virov  
3. **Izvedite dostop z najmanjšimi potrebnimi privilegiji**: Dodelite le nujne pravice  
4. **Nadzorujte vzorce izvajanja**: Zaznavajte nenavadno vedenje  

## Zaščita definicij orodij

Za preprečevanje zastrupitve orodij:

1. **Preverite definicije orodij pred uporabo**: Preverite prisotnost zlonamernih navodil ali neprimernih vzorcev  
2. **Uporabite preverjanje integritete**: Zgoščevanje ali podpis definicij orodij za zaznavanje nepooblaščenih sprememb  
3. **Izvedite spremljanje sprememb**: Opozorite na nepričakovane spremembe metapodatkov orodij  
4. **Uporabite verzioniranje definicij orodij**: Spremljajte spremembe in omogočite povrnitev, če je potrebno  

Ti ukrepi skupaj ustvarjajo robustno varnostno podlago za implementacije MCP, ki naslavljajo edinstvene izzive sistemov, ki jih poganja umetna inteligenca, hkrati pa ohranjajo močne tradicionalne varnostne prakse.

**Omejitev odgovornosti**:  
Ta dokument je bil preveden z uporabo AI prevajalske storitve [Co-op Translator](https://github.com/Azure/co-op-translator). Čeprav si prizadevamo za natančnost, vas opozarjamo, da avtomatizirani prevodi lahko vsebujejo napake ali netočnosti. Izvirni dokument v njegovem izvirnem jeziku velja za avtoritativni vir. Za ključne informacije priporočamo strokovni človeški prevod. Za morebitna nesporazume ali napačne interpretacije, ki izhajajo iz uporabe tega prevoda, ne odgovarjamo.