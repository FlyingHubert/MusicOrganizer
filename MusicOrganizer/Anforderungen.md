# Anforderungen

## Environment

+ [x] Die neue Applikation soll auf einem handelsüblichen Windows (7 oder 10) lauffähig sein
+ [x] Die Datenbank wird dateibasiert sein und soll einen Standard erfüllen der Zukunftsweisend ist
+ Um Datenverlust zu vermeiden schlage ich ein Backup pro Tag oder Start der Applikation vor, wenns recht ist
+ [x] Die Auflösung des Rechners ist mind. 1024 x 768

## Glossar

+ LP - Langspielplatte

## Szenarien

### Use Case 1: Eingabe von neuem Song

#### main flow

Die Haupteingabemaske des Programms ist zu sehen. Der Benutzer kann nun beliebige Werte in die Maske eintragen und diese anschließend durch Tastendruck oder Alternative speichern.

Zu den Werten die eingegeben werden können gehören:

+ Titel
+ Interpret
+ Titelgew **-> Was ist das? das Album?**
+ LP **-> Ist das die Langspielplatte?**
+ Art
+ Jahr
+ Komponist
+ Bemerkungen
+ **Was ist mit den anderen Angaben? Was ist davon noch relevant? Welche Felder sollen ggf. umbenannt werden?**

Bedienung:

+ [x] $F10$ -> Eingabe beendet
+ [x] $F5$ -> übernimmt den Wert des Feldes vom vorherigen Song (Wenn der Interpret vorher 'Elvis' war, so steht nach dem drücken von $F5$ 'Elvis' im Feld)

#### alternative flow

Die Eingabe mehrerer Songs hintereinander wird durchgeführt. Hier ist es möglich vorherige Eingaben wiederherzustellen um bspw. mehrere Songs des selben Albums einzugeben.

#### post condition

+  [x] Der Song befindet sich in der Datenbank
+  [x] Die Felder der Eingabemaske sind wieder leer
+ Das erste Feld der Maske ist angewählt

#### exceptional flow

Bei der Angabe doppelter Werte wird eine Meldung angezeigt die dies angibt. **Ist das relevant oder nur störend? :-P**

### Use Case 2: Suche von Song in der Datenbank

#### main flow

Der Benutzer gibt die ihm bekannten Werte in die Maske ein. Dabei werden fehlende Werte ausgelassen und nur teilweise bekannte Werte durch Punkte *Elv..* signalisiert.
Für numerische Werte lassen sich so auch Filter definieren z.B. *>100*. Durch drücken von $F10$ wird die Suchanfrage abgeschickt.

#### post condition

Das erste passende Ergebnis wird dem Benutzer in der Maske angezeigt. Durch das Drücken von $F9$ bzw. $F10$ lässt sich in den Ergebnissen Vor- und Zurückspringen. Die Anzeige bleibt dabei gleich.

#### alternative flow

Nach Eingabe der Suchkriterien kann in eine Tabelle gewechselt werden, die alle relevanten Ergebnisse anzeigt. Diese kann unter Angabe von Kriterien nach verschiedenen Parametern sortiert werden.

### Optionale Features

+ Eingabe *Elviz* -> *Meinten sie vielleicht **Elvis**?*
