# M120 Project - Cinema

## Run
Run the `.exe` file after the successful build of the source code, so that the datavalidation works properly without interrupting the program.

## Grundsätze der Dialoggestaltung
### Erwartungskonformität

Bei der Erwartungskonformität geht es um die Konsistenz und die Anpassung an Annahmen und Angaben über Benutzer.
Man orientiert sich also daran was er bereits kennt.

Umgesetzt wurde dies an mehreren Orten.
Zum einen wurde als Searchbutton eine Lupe, rechts von der Textbox die als Eingabe für das Suchwort dient implementiert.
Ebenso sind Selektier- und Bestätigungsknöpfe an der rechten Seiter des Fensters eingefügt worden, was meist so umgesetzt wird.
Generell ist das Layout so, wie man es sich als Benutzer gewohnt ist.
Oben am Fenster befindet sich ein Titel, eine kurze Erklärung und anschliessen in Spalten und Reihen aufgeteilt weitere Information, bzw Auswahlmöglichkeiten.

### Selbstbeschreibungsfähigkeit
Die Selbstbeschreibungsfähigkeit und die Verständlichkeit wurden gewährleistet durch Hilfen/Rückmeldungen

Erklärung der jeweiligen Fenster werden ganz am Anfang oben am Fenster platziert.
Ausserdem gehört zu jedem Textblock bzw. Eingabefeld ein Label, was erklärt, welche Information hier ersichtlich ist.
Bei der Ticketeingabe gibt es eine Rückmeldung, ob der eingegeben Wert valide ist.
Ebenfalls wird bei einer falschen Eingabe oder beim Nichtauswählen einer bestimmten Zeit eine Rückmeldung angezeigt als Folge des versuchten Buchens, die den User daraufhinweist, dass mindestens ein Ticket und eine Show ausgewählt werden muss für eine erfolgreiche Buchung.

### Robusheit gegemn Benutzerfehler
Validierung der Eingaben

Bei der Ticketeingabe gibt es eine Rückmeldung, ob der eingegeben Wert valide ist.
Ebenfalls wird bei einer falschen Eingabe oder beim Nichtauswählen einer bestimmten Zeit eine Rückmeldung angezeigt als Folge des versuchten Buchens, die den User daraufhinweist, dass mindestens ein Ticket und eine Show ausgewählt werden muss für eine erfolgreiche Buchung.
