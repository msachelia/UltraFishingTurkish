using HarmonyLib;
using UnityEngine;
using Object = UnityEngine.Object;
using System.Linq;

namespace UltraFishing;

[HarmonyPatch]
public static class LevelPatches {

  [HarmonyPostfix]
  [HarmonyPatch(typeof(GunControl), "Start")]
  private static void GunControl_Start_Postfix() {
    if (Object.FindObjectOfType<FishingHUD>() != null
        || Plugin.NoRodLevels.Contains(SceneHelper.CurrentScene)) return;

    GameObject fishManagerObj = new GameObject("FishManager");
    fishManagerObj.SetActive(value: false);
    fishManagerObj.AddComponent<FishManager>().fishDbs = new FishDB[] { };
    fishManagerObj.SetActive(value: true);

    SetupWaters();

    GameObject fishingCanvasClone = Object.Instantiate(Plugin.fishingCanvas);

    AddWeapon(5, Plugin.fishingRod);

    LoadFishTerminal();
  }

  private static void LoadFishTerminal() {
    string scene = SceneHelper.CurrentScene;

    if (!(scene.Contains("Level") || scene.Contains("construct") || scene.Contains("Museum"))) return;

    GameObject terminalClone;

    if (scene.Contains("construct")) {
      terminalClone = Object.Instantiate(Plugin.terminal);
      terminalClone.transform.position = new Vector3(-37, -10, 335.125f);
      terminalClone.transform.localEulerAngles = new Vector3(0, 0, 180);
      terminalClone.transform.GetChild(3).gameObject.layer = 24; //outdoors
      return;
    }

    GameObject firstRoom;
    switch (scene) {
      case "Level 6-1":
        firstRoom = GenericHelper.FindGameObject("Interiors/FirstRoom");
        break;
      default:
        firstRoom = GenericHelper.FindGameObjectContaining("FirstRoom");
        break;
    }

    if (firstRoom == null) {
      Plugin.logger.LogError("No FirstRoom could be found!");
      return;
    }

    terminalClone = Object.Instantiate(Plugin.terminal, firstRoom.transform.GetChild(0));
    terminalClone.transform.localPosition = new Vector3(-6.5f, 2, 32);
    terminalClone.transform.localEulerAngles = Vector3.zero;
  }

  private static void AddWeapon(int slot, GameObject weapon) {
    GunControl gunControl = GunControl.Instance;

    if (slot >= gunControl.slots.Count) return;

    if (gunControl.slots[slot].Exists(w => w.name == weapon.name + "Clone")) return;

    GameObject weaponClone = Object.Instantiate(weapon, gunControl.transform);
    gunControl.slots[slot].Add(weaponClone);
    gunControl.UpdateWeaponList(false);
    weaponClone.SetActive(value: false);
  }

  private static void SetupWaters() {
    switch (SceneHelper.CurrentScene) {
      case "uk_construct":
        WaterBuilder.SetWater("Water Tri")
          .AddFish("Şaklaban Salak Balık (Dost)")
          .AddFish("PITR Balığı")
          .AddFish("Alabalık")
          .AddFish("Metal Balık")
          .AddFish("Isırgan")
          .AddFish("Bomba Balığı")
          .AddFish("Gözbebeği")
          .AddFish("Kurbağa (?)")
          .AddFish("Ciks Balık")
          .AddFish("Balık Kroket")
          .AddFish("Pişmiş Balık")
          .AddFish("Köpek Balığı")
          .SetUp("Garry'nin Gölü", Color.green);
        break;
      case "CreditsMuseum2":
        WaterBuilder.SetWater("__Room_Aquarium/", 8)
          .AddFish("Şaklaban Salak Balık (Dost)")
          .AddFish("PITR Balığı")
          .AddFish("Alabalık")
          .AddFish("Metal Balık")
          .AddFish("Isırgan")
          .AddFish("Bomba Balığı")
          .AddFish("Gözbebeği")
          .AddFish("Kurbağa (?)")
          .AddFish("Ciks Balık")
          .AddFish("Balık Kroket")
          .AddFish("Pişmiş Balık")
          .AddFish("Köpek Balığı")
          .SetUp("Akvaryum", Color.cyan);
        WaterBuilder.SetWater("__Room_Courtyard/__Level Geo/Water Fountain/Water fountain_water_1")
          .AddFish("Sikke")
          .SetUp("Fıskiye", Color.cyan);
        WaterBuilder.SetWater("__Room_FrontDesk_1/__Level geo/Cube (3)")
          .AddFish("Bilge Balık")
          .SetUp("Katkısı Bulunanlar", Color.magenta);
        WaterBuilder.SetWater("__Room_Large_Lower/__Level Geo/water")
          .AddFish("Bilge Balık")
          .SetUp("Katkısı Bulunanlar", Color.magenta);
        break;
      case "Level 0-1":
        WaterBuilder.SetWater("6 - Glass Hallway/6 Nonstuff/Grinders/Pit/")
          .AddFish("Hurdacı Balık")
          .SetSplash("None")
          .SetUp("Kıyma Makinesi", Color.red);
        break;
      case "Level 0-2":
        WaterBuilder.SetWater("3 - Blood Room/3 Nonstuff/Decorations/Mulchflow")
          .AddFish("Bağırgan Balık (Pislık)")
          .SetUp("Çürük Akıntısı", Color.red);
        WaterBuilder.SetWater("3 - Blood Room/Grinders/Pit/")
          .AddFish("Hurdacı Balık")
          .SetSplash("None")
          .SetUp("Kıyma Makinesi", Color.red);
        WaterBuilder.SetWater("2 - Crusher Hallway/Grinders/Pit/")
          .AddFish("Hurdacı Balık")
          .SetSplash("None")
          .SetUp("Kıyma Makinesi", Color.red);
        WaterBuilder.SetWater("7B - Bonus Platforming/Grinders (2)/Pit/")
          .AddFish("Hurdacı Balık")
          .SetSplash("None")
          .SetUp("Kıyma Makinesi", Color.red);
        WaterBuilder.SetWater("3 - Blood Room/3 Nonstuff/Decorations/Mulchflow/Cube")
          .AddFish("Bağırgan Balık (Pislık)")
          .SetUp("Çürük Akıntısı", Color.red);
        WaterBuilder.SetWater("3 - Blood Room/3 Nonstuff/Decorations/Mulchflow (1)")
          .AddFish("Bağırgan Balık (Pislık)")
          .SetUp("Çürük Akıntısı", Color.red);
        WaterBuilder.SetWater("3 - Blood Room/3 Nonstuff/Decorations/Mulchflow (1)/Cube")
          .AddFish("Bağırgan Balık (Pislık)")
          .SetUp("Çürük Akıntısı", Color.red);
        WaterBuilder.SetWater("6 - Crusher Arena/6 Nonstuff/Floor", 4)
          .AddFish("Bağırgan Balık (Pislık)")
          .AddMeshCollider()
          .SetUp("Çürük Akıntısı", Color.red);
        WaterBuilder.SetWater("7 - Crusher Hallway/7 Nonstuff/Floor/Blood/")
          .AddFish("Bağırgan Balık (Pislık)")
          .SetUp("Çürük Akıntısı", Color.red);
        foreach (int childIndex in new int[] { 0, 1, 3, 5, 7 }) {
          WaterBuilder.SetWater("9-9B Tunnel/BloodRiver/", childIndex)
            .AddFish("Bağırgan Balık (Pislık)")
            .SetUp("Çürük Akıntısı", Color.red);
        }
        break;
      case "Level 0-3":
        GameObject wires = Plugin.bundle.LoadAsset<GameObject>(
            "assets/bundles/fishingstuff/level prefabs/Fishspots1.prefab"
            );
        GameObject wiresClone = Object.Instantiate(wires);
        foreach (Transform child in wiresClone.transform) {
          WaterBuilder.SetWater(child.gameObject)
            .AddFish("Vâyırşark")
            .SetSplash("Electricity")
            .SetUp("Kablo", Color.yellow);
          child.gameObject.GetComponent<FakeWater>().overrideFishingPoint = child.GetChild(0);
        }
        break;
      case "Level 0-5":
        WaterBuilder.SetWater("2 - Lava Foundry/Lava/", 0)
          .AddFish("Yanmış Balık")
          .SetUp("Lav", Color.red);
        WaterBuilder.SetWater("2 - Lava Foundry/Lava/", 1)
          .AddFish("Yanmış Balık")
          .SetUp("Lav", Color.red);
        break;
      case "Level 1-1":
        WaterBuilder.SetWater("6 - Waterfall Arena/6 Nonstuff/Cliff and Waterfall", 0, "GameObject")
          .AddFish("null")
          .SetUp("Şelale", Color.magenta);
        WaterBuilder.SetWater("6 - Waterfall Arena/6 Nonstuff/Cliff and Waterfall", 2, "GameObject")
          .AddFish("null")
          .SetUp("Şelale", Color.magenta);
        WaterBuilder.SetWater("7 - Castle Entrance/7 Nonstuff/Ground/Cube/")
          .AddFish("Nil")
          .SetUp("Akıntı", Color.magenta);
        // shitty fix for deltakill compat
        GameObject fountain = GenericHelper.FindGameObject("1 - First Field/1 Stuff/1 - Darker_Fountain(Clone)/fountain/Cylinder (1)");
        if (fountain == null) {
          fountain = GenericHelper.FindGameObject("1 - First Field/1 Stuff/Fountain/Cylinder"); // works but not after Sikke
        }
        WaterBuilder.SetWater(fountain)
          .AddFish("Sikke")
          .SetUp("Fıskiye", Color.cyan);
        break;
      case "Level 1-2":
        WaterBuilder.SetWater("7B - Lava Room/Floor/Lava/")
          .AddFish("Yanmış Balık")
          .SetUp("Lav", Color.red);
        foreach (Transform objects in GenericHelper.FindGameObject("7 - Castle Entrance/7 Nonstuff/Sewer/Water").transform) {
          WaterBuilder.SetWater(objects.gameObject)
            .AddFish("null")
            .SetUp("Kanalizasyon", Color.magenta);
        }
        WaterBuilder.SetWater("5 - Double Hallway/5 Nonstuff/Floor/", 8)
          .AddFish("Nil")
          .SetUp("Kanalizasyon Akıntısı", Color.magenta);
        WaterBuilder.SetWater("3 - Stairs Room/3 Nonstuff/Floor/", 7)
          .AddFish("Nil")
          .SetUp("Kanalizasyon", Color.magenta);
        ZoneBuilder.CreateZone()
          .SetPosition(0, -28.5f, 467.5f)
          .SetLocalScale(13, 13, 13)
          .SuggestedDistance(0.07f)
          .CustomMinDistance(1.4f);
        WaterBuilder.SetWater("7 - Castle Entrance/7 Nonstuff/Sewer/GreenWater")
          .AddFish("Kanserojen Balık")
          .SetUp("Kanserojen Su", Color.green);
        break;
      case "Level 1-3":
        WaterBuilder.SetWater("R2 - Second Arena/R2 Nonstuff/Lava")
          .AddFish("Yanmış Balık")
          .SetUp("Lav", Color.red);
        WaterBuilder.SetWater("B1-C Lava Staircase/B1-C Nonstuff/Floor/Cube")
          .AddFish("Yanmış Balık")
          .SetUp("Lav", Color.red);
        WaterBuilder.SetWater("B1-D Lava Hallway/B1-D Nonstuff/Lava/Cube-clone")
          .AddFish("Yanmış Balık")
          .SetUp("Lav", Color.red);
        foreach (Transform objects in GenericHelper.FindGameObject("R3 - Final Arena/R3 Nonstuff/Water/Water (Colliders)").transform) {
          WaterBuilder.SetWater(objects.gameObject)
            .AddFish("null")
            .SetUp("Şelale Havuzu", Color.magenta);
        }

        foreach (Transform objects in GenericHelper.FindGameObject("B2-B Stairs Hallway/B2-B Nonstuff/Water").transform) {
          WaterBuilder.SetWater(objects.gameObject)
            .AddFish("Nil")
            .SetUp("Akıntı", Color.magenta);
        }

        for (int i = 0; i < 5; i++) {
          if (i == 0 || i == 4) {
            WaterBuilder.SetWater("R1 - Courtyard/R1 Nonstuff/Decorations/Water", i)
              .AddFish("null")
              .SetUp("Şelale", Color.magenta);
          }
          else {
            WaterBuilder.SetWater("R1 - Courtyard/R1 Nonstuff/Decorations/Water", i)
              .AddFish("Nil")
              .SetUp("Su Kemeri", Color.magenta);
          }

        }

        for (int i = 0; i < 4; i++) {
          if (i != 0) {
            WaterBuilder.SetWater("B2 -> B2-B Water/Water/", i)
              .AddFish("null")
              .SetUp("Şelale", Color.magenta);
          }
        }

        WaterBuilder.SetWater("B2 -> B2-B Water/Water/Cube (2)/", 0)
          .AddFish("Nil")
          .SetUp("Akıntı", Color.magenta);
        WaterBuilder.SetWater("B2 -> B2-B Water/Water/Cube (2)/", 0)
          .AddFish("Nil")
          .SetUp("Akıntı", Color.magenta);
        WaterBuilder.SetWater("B2-A Water Hallway/B2-A Nonstuff/Floor/", 5)
          .AddFish("Nil")
          .SetUp("Akıntı", Color.magenta);
        WaterBuilder.SetWater("B2-A Water Hallway/B2-A Nonstuff/Floor/", 6)
          .AddFish("Nil")
          .SetUp("Akıntı", Color.magenta);
        WaterBuilder.SetWater("B2-A Water Hallway/B2-A Nonstuff/Floor/", 7)
          .AddFish("Nil")
          .SetUp("Akıntı", Color.magenta);
        WaterBuilder.SetWater("S - Secret Fight/S Nonstuff/Water/Cube/")
          .AddFish("NaN")
          .SetUp("Kapalı Havuz", Color.magenta);
        break;
      case "Level 1-4":
        WaterBuilder.SetWater("2 - Bridge/2 Nonstuff/Start Side/Plane/")
          .AddFish("null")
          .AddBoxCollider()
          .SetUp("Şelale", Color.magenta);
        WaterBuilder.SetWater("V2 - Arena/V2 Nonstuff/Floor/Water/")
          .AddFish("NaN")
          .SetUp("Küçük Havuz", Color.magenta);
        break;
      case "Level 2-1":
        WaterBuilder.SetWater("1 - New Opener/1 Nonstuff/Floor/Plane")
          .AddFish("Plastik Balık")
          .SetUp("Kanalizasyon", Color.blue);
        WaterBuilder.SetWater("1 - New Opener/1 Nonstuff/Floor/Plane-clone")
          .AddFish("Plastik Balık")
          .SetUp("Kanalizasyon", Color.blue);
        GameObject hankFisher = Plugin.bundle.LoadAsset<GameObject>(
            "assets/bundles/fishingstuff/level prefabs/hankfisher 1.prefab"
            );
        GameObject hankFisherClone = Object.Instantiate(hankFisher);
        WaterBuilder.SetWater(hankFisherClone.transform.Find("Fishpoint").gameObject)
          .AddFish("Kanatlı İblis Balığı")
          .SetSplash("None")
          .SetUp("Şehvet Semaları", Color.magenta);
        break;
      case "Level 2-2":
        WaterBuilder.SetWater("1 - First District/1 Nonstuff/Floor/Plane/Cube/")
          .AddFish("Vapor Balığı")
          .SetUp("Kanal", Color.cyan);
        for (int i = 0; i < GenericHelper.FindGameObject("5 - Second District/5 Nonstuff/Water/Colliders").transform.childCount; i++) {
          if (i > 1 && i < 6) {
            WaterBuilder.SetWater("5 - Second District/5 Nonstuff/Water/Colliders/", i)
              .AddFish("Plastik Balık")
              .SetUp("Kanalizasyon", Color.blue);
          }
          else {
            WaterBuilder.SetWater("5 - Second District/5 Nonstuff/Water/Colliders/", i)
              .AddFish("Vapor Balığı")
              .SetUp("Kanal", Color.cyan);
          }
        }

        break;
      case "Level 2-3":
        WaterBuilder.SetWater("2 - Sewer Arena/2 Nonstuff/Grinders/Pit")
          .AddFish("Hurdacı Balık")
          .SetSplash("None")
          .SetUp("Kıyma Makinesi", Color.red);
        WaterBuilder.SetWater("3 - Arena 2/3 Nonstuff/Obstacles/Grinders (1)/Pit")
          .AddFish("Hurdacı Balık")
          .SetSplash("None")
          .SetUp("Kıyma Makinesi", Color.red);
        WaterBuilder.SetWater("3 - Arena 2/3 Nonstuff/Obstacles/Grinders/Pit")
          .AddFish("Hurdacı Balık")
          .SetSplash("None")
          .SetUp("Kıyma Makinesi", Color.red);
        foreach (Transform child in GenericHelper.FindGameObject("1 - Main Hall/1 Nonstuff/Water/").transform) {
          if (child.name.Contains("Cube")) {
            WaterBuilder.SetWater(child)
              .AddFish("Aynalı Sazan Balığı")
              .SetUp("Gölet", Color.magenta);
          }
        }
        for (int i = 0; i < 3; i++) {
          WaterBuilder.SetWater("2 - Sewer Arena/2 Nonstuff/Water", i)
            .AddFish("Plastik Balık")
            .SetUp("Kanalizasyon Şelalesi", Color.cyan);
        }
        WaterBuilder.SetWater("5 - Final Arena/5 Nonstuff/Water (Controlled)/Cube")
          .AddFish("Plastik Balık")
          .SetUp("Kanalizasyon Şelalesi", Color.cyan);
        break;
      case "Level 3-1":
        WaterBuilder.SetWater("2 - Tallway/2 Nonstuff/Floor/Water/")
          .AddFish("Gözbebeği")
          .SetUp("Kan", Color.red);
        WaterBuilder.SetWater("7 - Bridge Arena/7 Nonstuff/Water/")
          .AddFish("Gözbebeği")
          .SetUp("Kan", Color.red);
        // needs work
        WaterBuilder.SetWater("7 - Bridge Arena/7 Nonstuff/Water (1)/")
          .AddFish("Gözbebeği")
          .SetUp("Kan", Color.red);
        WaterBuilder.SetWater("5 - Circular Arena/5 Nonstuff/Water/")
          .AddFish("Kurbağa (?)")
          .SetUp("Kan", Color.red);
        WaterBuilder.SetWater("3 - Big Arena/3 Nonstuff/Floor/Acid/")
          .AddFish("Erimiş Balık")
          .SetUp("Asit", Color.green);
        WaterBuilder.SetWater("9 - Uphill Battle/9 Nonstuff/Floor/Acid/Cube")
          .AddFish("Erimiş Balık")
          .SetUp("Asit", Color.green);
        WaterBuilder.SetWater("9 - Uphill Battle/9 Nonstuff/Floor/Acid/Cube (1)")
          .AddFish("Erimiş Balık")
          .SetUp("Asit", Color.green);
        WaterBuilder.SetWater("10 - Structure/10 Stuff/AcidRaiser (1)/AcidRaiser/Acid/")
          .AddFish("Erimiş Balık")
          .SetUp("Asit", Color.green);
        break;
      case "Level 3-2":
        WaterBuilder.SetWater("3 - Other Room/3 Nonstuff/Water/")
          .AddFish("Erimiş Balık")
          .SetUp("Asit", Color.green);
        break;
      case "Level 4-1":
        foreach (Transform objects in GenericHelper.FindGameObject("6 - Staircase Arena/6 Nonstuff/Pit/Lava/").transform) {
          WaterBuilder.SetWater(objects.gameObject)
            .AddFish("Yanmış Balık")
            .SetUp("Lav", Color.red);
        }
        foreach (Transform objects in GenericHelper.FindGameObject("Exterior Areas/1 Nonstuff/Water/").transform) {
          WaterBuilder.SetWater(objects.gameObject)
            .AddFish("Antik Balık")
            .SetUp("Kaynar Havuz", Color.cyan);
        }
        break;
      case "Level 4-2":
        for (int i = 0; i < 7; i++) {
          WaterBuilder.SetWater("Dunes", i)
            .AddFish("Sikke")
            .SetSplash("Sand")
            .SetUp("Kum", Color.yellow);
        }
        break;
      case "Level 4-3":
        WaterBuilder.SetWater("3 - Traitor Hallway/3B - Tomb of Kings/3B Nonstuff/Entrance/Walls/Cube (99)")
          .AddFish("Sikke")
          .SetUp("Altın", Color.yellow);
        WaterBuilder.SetWater("3 - Traitor Hallway/3B - Tomb of Kings/3B Nonstuff/Entrance/Walls/Cube (100)")
          .AddFish("Sikke")
          .SetUp("Altın", Color.yellow);
        foreach (Transform objects in GenericHelper.FindGameObject("5 - Cerberus Room/5 Nonstuff/Water/").transform) {
          WaterBuilder.SetWater(objects.gameObject)
            .AddFish("Antik Balık")
            .SetUp("Sıcak Havuz", Color.cyan);
        }
        break;
      case "Level 4-4":
        WaterBuilder.CreateWater("8 - Outro/8 Stuff/Landing (Broken) (1)")
          .SetPosition(1065, 255, 692)
          .SetLocalScale(9, 0, 9)
          .AddBoxCollider()
          .AddFish("Gözbebeği")
          .SetUp("\"V2\"", Color.red);
        WaterBuilder.SetWater("8 - Outro/8 Nonstuff/Untilted (Outro)/Cube(Clone) (1)/")
          .AddFish("Sikke")
          .SetSplash("Sand")
          .SetUp("Kum", Color.yellow);
        foreach (Transform objects in GenericHelper.FindGameObject("3 - Ground Floor/Hallway/Sands/").transform) {
          WaterBuilder.SetWater(objects.gameObject)
            .AddFish("Sikke")
            .SetSplash("Sand")
            .SetUp("Kum", Color.yellow);
        }
        WaterBuilder.SetWater("3 - Ground Floor/Sand Hall/Sand/")
          .AddFish("Sikke")
          .SetSplash("Sand")
          .SetUp("Kum", Color.yellow);
        WaterBuilder.SetWater("5 - Window Hallway/Floor/", 5)
          .AddFish("Antik Balık")
          .SetUp("Küçük Havuz", Color.cyan);
        WaterBuilder.SetWater("5 - Window Hallway/Floor/", 6)
          .AddFish("Antik Balık")
          .SetUp("Küçük Havuz", Color.cyan);
        WaterBuilder.SetWater("3 - Ground Floor/Secret Hall/SuperSecretActivator/")
          .AddFish("Antik Balık")
          .SetUp("Küçük Havuz", Color.cyan);
        break;
      case "Level 5-1":
        WaterBuilder.SetWater("Underwaters/All Waters/Cube (3)")
          .AddFish("Şaklaban Salak Balık (Dost)")
          .AddFish("PITR Balığı")
          .SetUp("Mağara Gölü", Color.cyan);
        WaterBuilder.SetWater("IntroParent/Intro/Intro A - First Cave/Plane/Cube")
          .AddFish("Isırgan")
          .SetUp("Mağara Havuzu", Color.gray);
        WaterBuilder.SetWater("IntroParent/Intro/Intro A - First Cave/Plane (1)/Cube")
          .AddFish("Isırgan")
          .SetUp("Mağara Havuzu", Color.gray);
        WaterBuilder.SetWater("IntroParent/Intro/Intro C - Second Cave/Plane (2)/Cube")
          .AddFish("Isırgan")
          .SetUp("Mağara Havuzu", Color.gray);
        WaterBuilder.SetWater("2B - Arena B/B Nonstuff/Water/Cube")
          .AddFish("Isırgan")
          .SetUp("Mağara Havuzu", Color.gray);
        WaterBuilder.SetWater("1 - Main Cave/1 Nonstuff/Drained/Cube")
          .AddFish("Ciks Balık")
          .SetUp("Mağara Gölü", Color.cyan);
        WaterBuilder.SetWater("2A - Arena A/A Nonstuff/Drained (1)/Cube")
          .AddFish("PITR Balığı")
          .AddFish("Şaklaban Salak Balık (Dost)")
          .SetUp("Mağara Gölü", Color.cyan);
        break;
      case "Level 5-2":
        WaterBuilder.SetWater("Sea/Sea Itself/Filler/WaterTrigger")
          .AddFish("İnek Köpek Balığı", 0)
          .AddBait("3 - Ferryman's Cabin/3 Nonstuff/Interior/Book with Stand/Book", "İnek Köpek Balığı")
          .SetUp("Styx Okyanusu", Color.blue);
        break;
      case "Level 5-3":
        WaterBuilder.CreateWater("Unrotated/2B1 - Lounge Bar/2B1 Nonstuff/Bar/")
          .SetPosition(0, -12.25f, 478.25f)
          .SetLocalScale(20, 2, 5)
          .AddFish("Poisson de Vin")
          .SetSplash("Bottles")
          .SetUp("Bar", new Color(0.54f, 0.2f, 0.65f, 1));
        GameObject bar = GenericHelper.FindGameObject("Unrotated/2B1 - Lounge Bar/2B1 Nonstuff/Bar/");
        GameObject baroverride = new GameObject();
        baroverride.transform.parent = bar.transform.GetChild(3).transform;
        baroverride.transform.localPosition = new Vector3(0, 0, 0);
        bar.transform.GetChild(3).GetComponent<FakeWater>().overrideFishingPoint = baroverride.transform;
        break;
      case "Level 5-4":
        WaterBuilder.SetWater("Surface/Stuff/Watersurface/Cube")
          .AddFish("Yılanbalığı (?)")
          .SetUp("Styx Okyanusu", Color.blue);
        WaterBuilder.SetWater("Surface/Stuff/Watersurface/Cube (1)")
          .AddFish("Yılanbalığı (?)")
          .SetUp("Styx Okyanusu", Color.blue);
        WaterBuilder.SetWater("Surface/Stuff/Watersurface/Cube (2)")
          .AddFish("Yılanbalığı (?)")
          .SetUp("Styx Okyanusu", Color.blue);
        WaterBuilder.SetWater("Surface/Stuff/Watersurface (Sunken)/NewDeath/Anti-diver Colliders/Cube")
          .AddFish("Yılanbalığı (?)")
          .SetUp("Styx Okyanusu", Color.blue);
        for (int i = 0; i < 8; i++) {
          WaterBuilder.SetWater("Surface/Stuff/Watersurface (Sunken)/NewWater/", i)
            .AddFish("Yılanbalığı (?)")
            .SetUp("Styx Okyanusu", Color.blue);
        }
        break;
      case "Level 6-1":
        WaterBuilder.SetWater("Interiors/6 - Lava Chasm/6 Nonstuff/Lava")
          .AddFish("Yanmış Balık")
          .SetUp("Lav", Color.red);
        WaterBuilder.SetWater("10 - Chapel/10 Nonstuff/Pit")
          .AddFish("Yanmış Balık")
          .SetUp("Lav", Color.red);
        WaterBuilder.SetWater("14 - Hall of Sacreligious Remains/14 Nonstuff/Lava Rim/Lava/Cube (9)")
          .AddFish("Yanmış Balık")
          .SetUp("Lav", Color.red);
        WaterBuilder.SetWater("14 - Hall of Sacreligious Remains/14 Nonstuff/Lava Rim/Lava/Cube (9)/Cube (7)")
          .AddFish("Yanmış Balık")
          .SetUp("Lav", Color.red);
        WaterBuilder.SetWater("14 - Hall of Sacreligious Remains/14 Nonstuff/Lava Rim/Lava/Cube (6)")
          .AddFish("Yanmış Balık")
          .SetUp("Lav", Color.red);
        WaterBuilder.SetWater("14 - Hall of Sacreligious Remains/14 Nonstuff/Lava Rim/Lava/Cube (6)/Cube (7)")
          .AddFish("Yanmış Balık")
          .SetUp("Lav", Color.red);
        break;
      case "Level 7-1":
        WaterBuilder.SetWater("First Section/Opening Halls Geometry/Opening Nonstuff/Triangle Room/Water/")
          .AddFish("Manken Balığı")
          .SetUp("Sığ Su Havuzu", Color.white);
        WaterBuilder.SetWater("First Section/Opening Halls Geometry/Opening Nonstuff/Curved Turn/Water/")
          .AddFish("Manken Balığı")
          .SetUp("Kavisli Su Havuzu", Color.white);
        WaterBuilder.SetWater("Second Section/2 - Left Arena/2 Nonstuff/Water/")
          .AddFish("Manken Balığı")
          .SetUp("Su Birikintisi", Color.white);
        WaterBuilder.SetWater("Second Section/4 - Interior Exterior/4 Nonstuff/Building/Floor 1/Water/")
          .AddFish("Manken Balığı")
          .SetUp("Sığ Su Havuzu", Color.white);
        break;
      case "Level 7-2":
        //optionally, Outdoors/12 - Red Skull Trench/12 Nonstuff/Water
        WaterBuilder.SetWater("Outdoors/Decorations/Ground/Blood")
          .AddFish("Bomba Balığı")
          .SetUp("Flegethon Nehri", Color.black);
        WaterBuilder.SetWater("Intro Interiors/5 - Corner Staircase/Secret/Water/")
          .AddFish("Manken Balığı")
          .SetUp("Su Birikintisi", Color.white);
        break;
      case "Level 7-3":
        WaterBuilder.SetWater("Outdoors Areas/Geometry/5/Water/")
          .AddFish("Manken Balığı")
          .SetUp("Su Birikintisi", Color.white);
        WaterBuilder.SetWater("Outdoors Areas/Geometry/5 -> 3/Secret 1/", 2)
          .AddFish("Manken Balığı")
          .SetUp("Şelale Kanalı", Color.white);
        WaterBuilder.SetWater("Outdoors Areas/Geometry/10/Water/")
          .AddFish("Manken Balığı")
          .SetUp("Küçük Havuz", Color.white);
        WaterBuilder.SetWater("3 - Central Plaza/3 Nonstuff/Tree Area/Cube/")
          .AddFish("Leziz Balık")
          .SetSplash("None")
          .SetUp("Kan Ağacı'nın Kökleri", Color.red);
        WaterBuilder.SetWater("Outdoors Areas/Geometry/9/Floor/", 2)
          .AddFish("Leziz Balık")
          .SetSplash("None")
          .SetUp("Kana Bulanmış Çim", Color.red);
        foreach (Transform water in GenericHelper.FindGameObject("12 - Grand Hall/12 Nonstuff/Water/").transform) {
          WaterBuilder.SetWater(water)
            .AddFish("Manken Balığı")
            .SetUp("Büyük Havuz", Color.white);
        }

        LateSetWater late = GenericHelper.FindGameObject("12 - Grand Hall/12 Stuff/SuicideTreeHungry/BloodLeaves/BigLeaves/").AddComponent<LateSetWater>();

        late.WaterName = "Büyük Kan Göleti";
        late.color = Color.red;
        late.Addfish("Leziz Balık");

        foreach (Transform water in GenericHelper.FindGameObject("12 - Grand Hall/12 Nonstuff/Water/").transform) {
          late.AddObject(water);
        }
        break;
      case "Level 7-4":
        WaterBuilder.SetWater("Main/Interior/InteriorStuff/BoilingBlood")
          .AddFish("Erimiş Balık")
          .SetUp("Cihansarsan'ın İç Yapısı", Color.black);
        WaterBuilder.SetWater("Main/Interior/InteriorStuff/BoilingBlood (Return)")
          .AddFish("Erimiş Balık")
          .SetUp("Cihansarsan'ın İç Yapısı", Color.black);
        break;
      case "Level 7-S":
        WaterBuilder.SetWater("Pond/Pond Underwater")
          .AddFish("Aynalı Sazan Balığı")
          .SetUp("Gölet", Color.white);
        WaterBuilder.SetWater("Pit/PitDestroyer")
          .AddFish("Bilge Balık")
          .SetSplash("Books")
          .SetUp("Kütüphanenin Derinlikleri", Color.gray);
        WaterBuilder.SetWater("Curved Pit Destroyer")
          .AddFish("Bilge Balık")
          .SetSplash("Books")
          .SetUp("Kütüphanenin Derinlikleri", Color.gray);
        WaterBuilder.SetWater("Curved Pit Destroyer/GameObject")
          .AddFish("Bilge Balık")
          .SetSplash("Books")
          .SetUp("Kütüphanenin Derinlikleri", Color.gray);
        WaterBuilder.SetWater("7-S_Unpaintable/Exterior/The Water Ups_Todo/The Water Ups/Water Ups Ocean")
          .AddFish("\"boyut 2\"", GlobalFishManager.Size2Chance())
          .AddMeshCollider(false)
          .SetUp("Sukarı", Color.blue);
        break;
      case "Level P-1":
        WaterBuilder.SetWater("3 - Fuckatorium/3 Stuff/FleshPrisonWave/Flesh Prison/")
          .AddFish("Kadim Balık")
          .SetSplash("None")
          .SetUp("Et Hapis", Color.black);
        break;
      case "Level P-2":
        WaterBuilder.SetWater("Shortcut/Deathzones/Deathzone")
          .AddFish("Metal(?) Balık")
          .SetSplash("None")
          .SetUp("Scrindongulodlanan Ruhlar", Color.black);
        WaterBuilder.SetWater("Shortcut/Deathzones", 2)
          .AddFish("Metal(?) Balık")
          .SetSplash("None")
          .SetUp("Scrindongulodlanan Ruhlar", Color.black);
        WaterBuilder.SetWater("Main Section/Outside/2 - Bridge Street/Floor/Plane (2)/Plane")
          .AddFish("Metal(?) Balık")
          .SetSplash("None")
          .SetUp("Scrongllanan Ruhlar", Color.black);
        WaterBuilder.SetWater("Main Section/Outside/2 - Bridge Street/Floor/Plane (3)")
          .AddFish("Metal(?) Balık")
          .SetSplash("None")
          .SetUp("Scrongllanan Ruhlar", Color.black);
        WaterBuilder.SetWater("Main Section/Outside/2 - Bridge Street/Floor/Plane (3)/Plane (1)")
          .AddFish("Metal(?) Balık")
          .SetSplash("None")
          .SetUp("Scrongllanan Ruhlar", Color.black);
        WaterBuilder.SetWater("Main Section/Inside/6 - Soul Tunnel/6 Nonstuff (1)/Soulwalls/Cube(Clone)")
          .AddFish("Metal(?) Balık")
          .SetSplash("None")
          .SetUp("Lanetlenmiş Ruhlar", Color.black);
        WaterBuilder.SetWater("Main Section/Inside/6 - Soul Tunnel/6 Nonstuff (1)/Soulwalls", 2)
          .AddFish("Metal(?) Balık")
          .SetSplash("None")
          .SetUp("Lanetlenmiş Ruhlar", Color.black);
        WaterBuilder.SetWater("Main Section/Inside/6 - Soul Tunnel/6 Nonstuff/Soulwalls/Cube(Clone)")
          .AddFish("Metal(?) Balık")
          .SetSplash("None")
          .SetUp("Lanetlenmiş Ruhlar", Color.black);
        WaterBuilder.SetWater("Main Section/Inside/6 - Soul Tunnel/6 Nonstuff/Soulwalls", 2)
          .AddFish("Metal(?) Balık")
          .SetSplash("None")
          .SetUp("Lanetlenmiş Ruhlar", Color.black);
        WaterBuilder.SetWater("Main Section/9 - Boss Arena/Boss Stuff/PrisonPhase/Flesh Prison 2/")
          .AddFish("Kadim Balık")
          .SetSplash("None")
          .SetUp("Et Panoptikon", Color.yellow);
        break;
      case "Level 0-E":
        WaterBuilder.SetWater("6 - Crossroads/6 Nonstuff/6 Hot Only/Blood")
          .AddFish("Bağırgan Balık (Pislık)")
          .SetUp("Çürük Akıntısı", Color.red);
        WaterBuilder.SetWater("8 - Lava Foundry/8 Hot Only/Lava (1)/Cube")
          .AddFish("Yanmış Balık")
          .SetUp("Lav", Color.red);
        WaterBuilder.SetWater("5-6 Water")
          .AddFish("Dondurulmuş Balık")
          .SetUp("Dondurucu Su", Color.white);
        break;
      case "Level 1-E":
        WaterBuilder.SetWater("13 - Crusher Hallway/13 Nonstuff/Grinders/Pit")
          .AddFish("Hurdacı Balık")
          .SetSplash("None")
          .SetUp("Kıyma Makinesi", Color.red);
        WaterBuilder.SetWater("2 - Skull Field % Blue Skull Room/2 Nonstuff/Return Trip Nonstuff/Lava/")
          .AddFish("Yanmış Balık")
          .SetUp("Lav", Color.red);
        WaterBuilder.SetWater("1 - First Field % Skylight Hallway/1 Nonstuff/1 Lava/Cube")
          .AddFish("Yanmış Balık")
          .SetUp("Lav", Color.red);
        WaterBuilder.SetWater("4 - Bridge/4 Nonstuff/4 Unburned/Plane/")
          .AddFish("null")
          .AddFish("Nil")
          .AddFish("NaN")
          .AddBoxCollider()
          .SetUp("Hatalı Havuz", Color.magenta);
        break;
    }
  }
}

