# Közösségi autómegosztó szolgáltatás adatbázis-kezelő alkalmazása
---
# A projekt alapötlete
A projekthez az ötletet az Adatbázisok tárgyhoz készült beadandó feladatomból vettem.  
Ennek során egy közösségi autómegosztó (e-carsharing) alkalmazás adatbázisát terveztem meg.  
Jelen projekthez is ezt az adatbázist használtam fel, némileg átalakítva.  

### A projekt alapját adó szolgáltatás működése

>A szolgáltatásra való regisztrációkor az alkalmazás rögzíti a felhasználó személyes  
>adatait, valamint a jogosítványa adatait, mivel enélkül az autóbérlés nem lehetséges.  
>Ezután a felhasználó kiválaszthatja a számára legoptimálisabb előfizetési konstrukciót  
>(havidíj valamint alacsonyabb percdíj, vagy havidíj nélkül, de magasabb percdíj).  
>Ezt követően megjelenik a szolgáltatási övezet térképe amin szerepelnek az elérhető autók,  
>valamint ezek adatai (típus, pozíció, töltöttség). Többféle típusú, méretű autó is rendelkezésre  
>állhat, bizonyos típusoknál feláras is lehet annak a használata. A jármű kiválasztása után a  
>felhasználó lefoglalhatja azt, a mobilalkalmazás segítségével indíthatja és használhatja.  
>A bérlés végeztével az autót le kell parkolni a szolgáltatási övezeten belül, és az alkalmazásban  
>leállítani a bérlést. Ha bármilyen problémát észlel az autóval (tisztasági probléma, törés stb.)  
>ezt ekkor jelentheti, képekkel dokumentálhatja, ez a rendszerben rögzítésre kerül.  
>A bérlés lezárását követően a rendszer elkészíti a számlát az előfizetése, bérlés időtartama, illetve  
>esetlegesen az autó felára alapján, amit a felhasználónak ki kell egyenlítenie. A bérlés végétől  
>az autó ismét elérhetővé válik a többi felhasználó számára is.  

# A projekt felhasználási lehetőségei
* A C# projekt felhasználható az adatbázissal kapcsolatos műveletek kezelésére. 
    * Felhasználók regisztrációja
    * Felhasználó adatainak módosítása, törlése
       * Jogosítvány hozzáadása, törlése
    * Autók hozzáadása, módosítása, törlése
    * Bérlések adatainak hozzáadása, módosítása, törlése
* A Java projekttel a felhasználó a várható használati adatok megadása után  megkapja a számára legoptimálisabb előfizetési konstrukciót.