# Elemente-de-grafica-pe-calculator
"# Elemente-de-grafica-pe-calculator" 

Laborator 2 raspunsuri:
2.1. In functie de atributele pe care le dam metodei viewport locul in care este randat triunghiul se schimba.
In openTK constanta MatrixMode.Projection nu isi poate schimba valoarea.
2.3. Un viewport este regiunea in cardul unei ferestre de afisare OpenGL in care se deseneaza grafic.
Conceptul de frames per second reprezinta numarul de imagini care trebuie create in fiecare secunda de catre OpenGL.
Metoda OnUpdateFrame() este rulata in fiecare cadru al aplicatii si este responsabila pentru logica aplicatiei.
Modul imediat de randare implica o metoda grafica care presupune transmiterea s desenarea directa a fiecarui varf sau obiect grafic catre GPU in fiecare cadru.
Ultima versiune in care este acceptat modul imediat de OpenGl este 3.0.
Metoda OnRenderFrame este apelata in fiecare cadru de desenare al aplicatiei.
Metoda OnResize trebuie sa fie executata cel putin o data deoarece aceasta permite aplicatiei sa reactioneze corect la schimbarile de dimensionare ale ferestrei.
Paramerii metodei CreatePerspectiveFieldOfView reprezinta: 'fovy' - field of view y, 'aspect' - aspect ratio, 'zNear' 'zFar' - distanta de la camera la obiect.

Laborator 3 raspunsuri:
3.1. Vertexurile se vor desena in sens orar.
3.2. Anti-aliasing este o tehnica folosita in grafica pentru a reduce efectul de asperitati in imagini si texte afisate pe ecrane.
3.3. Prima comanda, GL.LineWidth(float) seteaza grosimea liniilor care urmeaza a fi desenate in OpenGL. Grosimea liniei este reprezentata de parametrul din paranteze care este de tip float. A doua comanda, GL.PointSize(float) seteaza dimensiunea punctelor care urmeaza a fi desenate in OpenGL. La fel ca si la prima comanda, parametrul float reprezinta dimensiunea.
Pentru a fi executate corect ambele comenzi ar trebui sa se affle in interiorul unui bloc GL.Begin().
3.4. A. Rezultatul directivei va fi un poligon inchis, nu doar un contur.
B. Rezultatul utilizarii directivei este o serie de segmente consecutive, fara a creea o forma inchisa.
C. Rezultatul este un desen care este de folos atunci cand dorim sa cream forme in jurul unui punct central.
D. Rezultatul este o multime de triunghiuri conectate intre ele care poate fi folosita in a crea forme complexe.
3.6. Utilizarea de culori diferite si a unui gradient prezinta multe avantaje precum perceptia adancimii formei desenate, lumina si umbre
3.7. Un gradient de culoare reprezinta tranzitia intre 2 sau mai multe culori cu scopul de a creea un efect vizual placut.

Laborator 10 raspunsuri:
10.1 Observ ca ordinea de texturare a imaginilor este importanta, si nerespectarea ordinei poate duce la efecte nedorite.
10.2 Formatele de imagine care pot fi aplicate în procesul de texturare sunt: BMP, GIF, HDR, JPG, LBM, PCD, PCX, PIC, PNG, PNM, PSD, TGA, TIFF, și WBMP.
10.3 Daca modificam direct culorile RGB ale unui obiect texturat aceste modificari vor afecta cum este afisata textura pe obiect. Coloarea texturii se va amesteca cu culoarea obiectului.
10.4 Atunci cand lumina este activata obiectele pot creea umbre, iar atunci cand lumina este oprita acestea tind sa aiba o culoare mai uniforma si par mai putin realiste.
