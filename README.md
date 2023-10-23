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
