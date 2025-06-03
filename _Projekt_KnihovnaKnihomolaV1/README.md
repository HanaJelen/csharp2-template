# Závěrečný projekt - Knihovna pro knihomola

Co by měla umět:

-- funkci ADD:

- vytvoří novou knihovnu (list, který bude obsahovat jednotlivé objekty knihy)
- přidá knihu (typu fiction, non-fiction, audio, wishbook) do konkrétní knihovny (do listu => 1 list = 1 fyzická knihovna, místo uložení knihy)
- kniha typu wishbook se umístí do wishlistu automaticky
- přidá knihu do serie (dictionary), pokud je součástí serie
  
-- funkce LIST:

- vypíše abecední seznam knih v konkrétní knihovně dle zadání
- vypíše wishlist
- vypíše knihy konkrétní serie a to i z knihoven i z wishlistu

-- funkce FIND:

- vyhledání knih/knihy dle klíčového slova obsaženého v názvu
- vyhledání knih/knihy dle autora
- vyhledání knih dle žánru/tématu
- vyhledání knih dle formátu - audio, rozsahu knihy (např. všechny knihy mající počet stran do 200)

-- funkce STATS:

- statistika dle autora, celkový počet knih v knihovně, průměrný počet stran jeho knih, žánr/žánry v jakých se autor pohybuje, průměrné hodnocení jeho knih
- statistika dle žánru, výpis žánrů/tématu a počet knih konkrétního žánru v knihovně
- žebříček top10 nejlépe hodnocených/nejhůře hodnocených

-- funkce MANAGE:

- odstranění konkrétní knihy
- přesun knih mezi knihovnami (listy), respektive změna umístění
- přesun knihy z wishlistu do knihovny a smazání z wishlistu
  
-- funkce END:

- ukončuje program
