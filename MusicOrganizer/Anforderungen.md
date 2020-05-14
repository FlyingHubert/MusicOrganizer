# Anforderungen

## Glossar

+ LP - Langspielplatte

## Szenarien

### Use Case 1: Eingabe von neuem Song

#### main flow

Die Haupteingabemaske des Programms ist zu sehen. Der Benutzer kann nun beliebige Werte in die Maske eintragen und diese anschließend durch Tastendruck oder Alternative speichern.

Zu den Werten die eingegeben werden können gehören:

+ Titel
+ Interpret
+ Titelgew **-> Was ist das?**
+ LP **-> Ist das die Langspielplatte?**
+ Jahr
+ Komponist
+ Bemerkungen
+ Single
+ Art **NEU: Enumeration mit festen Werten oder allg. Feld? -> konfigurierbar?**
+ **Was ist mit den anderen Angaben? Was ist davon noch relevant? Welche Felder sollen ggf. umbenannt werden?**

Bedienung:

+ $F10$ -> Eingabe beendet
+ $F5$ -> übernimmt den Wert des Feldes vom vorherigen Song (Wenn der Interpret vorher 'Elvis' war, so steht nach dem drücken von $F5$ 'Elvis' im Feld)

#### alternative flow

Die Eingabe mehrerer Songs hintereinander wird durchgeführt. Hier ist es möglich vorherige Eingaben wiederherzustellen um bspw. mehrere Songs des selben Albums einzugeben.

#### post condition

+ Der Song befindet sich in der Datenbank
+ Die Felder der Eingabemaske sind wieder leer
+ Das erste Feld der Maske ist angewählt

#### exceptional flow

Bei der Angabe doppelter Werte wird eine Meldung angezeigt die dies angibt. **Ist das relevant oder nur störend? :-P**

### Use Case 2: Suche von Song in der Datenbank

#### main flow

Der Benutzer gibt die ihm bekannten Werte in die Maske ein. Dabei werden fehlende Werte ausgelassen und nur teilweise bekannte Werte durch Punkte *Elv..* signalisiert.
Für numerische Werte lassen sich so auch Filter definieren z.B. *>100*. Durch drücken von $F10$ wird die Suchanfrage abgeschickt.

#### post condition

#### 

Der Benutzer 
 1. Angabe von bekannten Werten. Fehlende oder offene Werte mit $..$ angeben
 2. Angabe von LP > 100 -> Führt in der selben Maske zu einem Titel
 3. Die Anzeige kann nun entweder nach dem ersten Treffer gehen oder Alternativ in Form einer Tabelle erfolgen
    1. Die Tabelle lässt sich nach Kriterien sortieren -> Erst nach CD dann nach Interpret usw. (steigend, fallend!)
    2. Ist man in der Trefferansicht lässt sich mit Tastenkombinationen durch die ergebnisse blättern. Dabei ist nicht die Tabellenansich zu sehen, sondern die einzelansicht.