using UnityEngine;
using UnityEngine.AddressableAssets;
using System.Collections.Generic;
using System.IO;

namespace UltraFishing;

public static class GlobalFishManager {

  private static Dictionary<string, FishData> fishes = new Dictionary<string, FishData>();
  private static List<FishCollection> collections = new List<FishCollection>();

  public static void RegisterCollection(FishCollection collection) {
    collections.Add(collection);
    foreach (FishData fishData in collection.fishes) {
      fishes.Add(fishData.fish.fishName, fishData);
    }
  }

  public static void Start() {
    string savePath = Path.Combine(Plugin.modDir, "fish.save");

    (string, int)[] defaultFishes = {
      ("Assets/Data/Fishing/Fishes/Funny Stupid Fish.asset", 0), // Funny Stupid Fish (Friend)
      ("Assets/Data/Fishing/Fishes/pitr fish.asset", 1), // PITR Fish
      ("Assets/Data/Fishing/Fishes/Trout.asset", 2), // Trout
      ("Assets/Data/Fishing/Fishes/Amid Evil Fish.asset", 3), // Metal Fish
      ("Assets/Data/Fishing/Fishes/Chomper.asset", 4), // Chomper
      ("Assets/Data/Fishing/Fishes/Bomb Fish.asset", 5), // Bomb Fish
      ("Assets/Data/Fishing/Fishes/Gib Eye.asset", 6), // Eyeball
      ("Assets/Data/Fishing/Fishes/Iron Lung Fish.asset", 7), // Frog (?)
      ("Assets/Data/Fishing/Fishes/Dope Fish.asset", 8), // Dope Fish
      ("Assets/Data/Fishing/Fishes/Stickfish.asset", 9), // Stickfish
      ("Assets/Data/Fishing/Fishes/Cooked Fish.asset", 10), // Cooked Fish
      ("Assets/Data/Fishing/Fishes/Shark.asset", 11), // Shark
    };

    (string, int)[] customFishes = {
      ("assets/bundles/fishingstuff/fishes/filth fish.asset", 12), // Filthy Screaming Fish (Filsh)
      ("assets/bundles/fishingstuff/fishes/sword fish.asset", 25), // Scraphead Fish
      ("assets/bundles/fishingstuff/fishes/wire shark.asset", 26), // Wire Shark
      ("assets/bundles/fishingstuff/fishes/overcooked fish.asset", 20), // Overcooked Fish
      ("assets/bundles/fishingstuff/fishes/missing fish.asset", 13), // null
      ("assets/bundles/fishingstuff/fishes/nil fish.asset", 27), // Nil
      ("assets/bundles/fishingstuff/fishes/nan fish.asset", 28), // NaN
      ("assets/bundles/fishingstuff/fishes/coin fish.asset", 22), // Coin
      ("assets/bundles/fishingstuff/fishes/cancer fish.asset", 14), // Cancerous Fish
      ("assets/bundles/fishingstuff/fishes/flying demon fish.asset", 29), // Flying Demon Fish
      ("assets/bundles/fishingstuff/fishes/vapor fish.asset", 30), // Vapor Fish
      ("assets/bundles/fishingstuff/fishes/plastic fish.asset", 31), // Plastic Fish
      ("assets/bundles/fishingstuff/fishes/koi fish.asset", 15), // Koi Fish
      ("assets/bundles/fishingstuff/fishes/melted fish.asset", 16), // Melted Fish
      ("assets/bundles/fishingstuff/fishes/ancient fish.asset", 32), // Ancient Fish
      ("assets/bundles/fishingstuff/fishes/nerd shark.asset", 17), // Nerd Shark
      ("assets/bundles/fishingstuff/fishes/wine fish.asset", 33), // Poisson de Vin
      ("assets/bundles/fishingstuff/fishes/leviathan fish.asset", 18), // Eel (?)
      ("assets/bundles/fishingstuff/fishes/mannequin fish.asset", 34), // Mannequin Fish
      ("assets/bundles/fishingstuff/fishes/tasty fish.asset", 35), // Tasty Fish
      ("assets/bundles/fishingstuff/fishes/book fish.asset", 23), // Wise Fish
      ("assets/bundles/fishingstuff/fishes/frozen fish.asset", 21), // Frozen Fish
      ("assets/bundles/fishingstuff/fishes/death metal fish.asset", 19), // Metal(?) Fish
      ("assets/bundles/fishingstuff/fishes/prime fish.asset", 36), // Prime Fish
    };

    string size2 = "assets/bundles/fishingstuff/fishes/png fish.asset"; // "size 2"
    int size2SaveSlot = 24;

    FishCollection defaultCollection = new FishCollection("ULTRAKILL");
    for (int i = 0; i < defaultFishes.Length; i++) {
        FishObject fish = Addressables.LoadAssetAsync<FishObject>(defaultFishes[i].Item1).WaitForCompletion();
        int saveSlot = defaultFishes[i].Item2;
        defaultCollection.RegisterFish(PrepareFish(fish), savePath, saveSlot);
        }

    FishCollection ultrafishingCollection = new FishCollection("ULTRABALIKÇI");
    for (int i = 0; i < customFishes.Length; i++) {
      FishObject fish = Plugin.bundle.LoadAsset<FishObject>(customFishes[i].Item1);
      int saveSlot = customFishes[i].Item2;
      ultrafishingCollection.RegisterFish(PrepareFish(fish), savePath, saveSlot);
    }

    FishCollection size2Collection = new FishCollection("???");
    FishObject size2Fish = Plugin.bundle.LoadAsset<FishObject>(size2);
    size2Collection.RegisterFish(PrepareFish(size2Fish), savePath, size2SaveSlot);

    RegisterCollection(defaultCollection);
    RegisterCollection(ultrafishingCollection);
    RegisterCollection(size2Collection);
  }

  private static FishObject PrepareFish(FishObject fish) {
    switch (fish.fishName) {
      case "Wise Fish":
        fish.customPickup.gameObject.AddComponent<BookRandomizer>();
        fish.fishName = "Bilge Balık";
        fish.description = "Çok bilge bir balık. Kendisini bulabilen herkese engin bilgisini aktarır.\n\nKütüphanelerin en derin ve en karanlık köşelerinde bulunur.";
        break;
      case "Poisson de Vin":
        fish.worldObject.transform.Find("Liquid").gameObject.AddComponent<Liquid>();
        fish.fishName = "Poisson de Vin";
        fish.description = "Değerli ve lüks bir balık. Bu balığın yaşı ilerledikçe tadı daha da lezzetli hale geldiği söylenir; bu nedenle genellikle tüketilmeden önce uzun süre bekletilir.\n\nBu balığın vahşi doğada hiç bulunmuş olduğuna dair bir kayıt yoktur, ancak lüks yolcu gemileri gibi seçkin mekanlarda sıklıkla servis edilmektedir.";
        break;
      case "NaN":
        MaterialSwapper matSwap = fish.worldObject.transform.GetChild(1).gameObject.AddComponent<MaterialSwapper>();
        matSwap.mat = Plugin.bundle.LoadAsset<Material>("Assets/Bundles/fishingstuff/Skyboxes/FakeOldScreenField.mat");
        matSwap.layer = 28;
        matSwap.ignoreLevels = new List<string>(new string[]{
            "Level 1-1", "Level 1-2", "Level 1-3", "Level 1-4", "Level 1-E"
        });
        break;
      case "Prime Fish":
        MaterialSwapper matSwap1 = fish.worldObject.transform.GetChild(0).gameObject.AddComponent<MaterialSwapper>();
        matSwap1.mat = Plugin.bundle.LoadAsset<Material>("Assets/Bundles/fishingstuff/MinosPrimeBody.mat");
        matSwap1.layer = -1;
        matSwap1.ignoreLevels = new List<string>(new string[]{"Level P-2"});
        fish.fishName = "Kadim Balık";
        fish.description = "Çok güçlü bir ruhun yaydığı artık enerjiden oluşmuş olduğuna inanılan, son derece nadir bir balık.\n\nHer ne kadar kendisi büyük bir güce sahip olsa da, benzer yaratıkların bilinen o güçlü iradesinden yoksundur. Bununla birlikte melekler tarafından yasaklanmış sayıldığından, çoğu balıkçı bu balığı yakalamaya çalışmamanızı tavsiye eder.";
        break;
      case "Funny Stupid Fish (Friend)":
        fish.fishName = "Şaklaban Salak Balık (Dost)";
        fish.description = "Aptal bir balık. Gerçekten çok aptal bir balık. Gerizekalı. Enayinin önde gideni. Beceriksiz salak. Ama mizahı iyidir.\n\nYakalaması kolaydır ve dost canlısıdır, genelde çocuklara balık tutmayı öğretmek için kullanılır.";
        break;
      case "PITR Fish":
        fish.fishName = "PITR Balığı";
        fish.description = "Çok zeki bir balık. Kedilere hayran. Kıyıya yakın yüzer ve genelde balıkçıları mutlu etmek için kasten oltalarına takılır.\n\nBalık besin zincirinin hep en altındadır.";
        break;
      case "Trout":
        fish.fishName = "Alabalık";
        fish.description = "Gölde bulunan sıradan bir balık. Derinlikleri tercih eder.\n\nİnsanlar tarafından sevilen bir balık türü olsa gerek, bu balığa benzer maskelerin bile yapıldığı bilinir.";
        break;
      case "Metal Fish":
        fish.fishName = "Metal Balık";
        fish.description = "Uzak diyarlardan gelen göçmen bir balık. Beslenme türü taş olduğu için kayalık yerlerde hayatta kalabilir.\n\nSadece beslenmek için su yüzüne çıkar.";
        break;
      case "Chomper":
        fish.fishName = "Isırgan";
        fish.description = "Göçmen bir balık.\n\nPensilvanya'dan geldiği için tercihen nemli, karanlık ve mutsuz ortamlarda yaşar.";
        break;
      case "Bomb Fish":
        fish.fishName = "Bomba Balığı";
        fish.description = "Olağanüstü balıklardan. Genelde akarsuları tercih eder, duru sularda hayat kendisi için renksiz ve monotondur.\n\nDikkatsiz balıkçıların başına iş açacak kendini savunma yöntemi vardır.";
        break;
      case "Eyeball":
        fish.fishName = "Gözbebeği";
        fish.description = "Sıradan bir balık. Hayatta kalması için kana ihtiyaç duyar.\n\nGörme duyusunu güçlendirir.";
        break;
      case "Frog (?)":
        fish.fishName = "Kurbağa (?)";
        fish.description = "Derinliği seven göçmen bir balık. Genelde uydu gezegenlerde yaşar, fakat yeterince kanın olduğu her yerde bulunabilir.\n\nÇok bölgesel bir balık, derinliklerden kesinlikle ayrılmaz ve yaklaşanlara da saldırır.";
        break;
      case "Dope Fish":
        fish.fishName = "Ciks Balık";
        fish.description = "Göçmen balık. Her yerde bulunabilir, ama genelde Kuytu köşelerden çıkarılır.\n\nGenelde maceraperestlerin ve kahramanların yanlışlıkla rastladığı bir balık türü. İyi şans getirdiği söylenir.";
        break;
      case "Stickfish":
        fish.fishName = "Balık Kroket";
        fish.description = "Düz balık. Yenebilir ve genelde insanlar üretir.\n\nDünyadaki bütün mutfaklarda bulunabilir.";
        break;
      case "Cooked Fish":
        fish.fishName = "Pişmiş Balık";
        fish.description = "Sıradan bir balık. Ateşte yaşar. Çiğ balıkları yemek için yaşam alanından dışarı çıkabilir.\n\nMuazzam bir lezzete sahip olduğu söylenir. Balıkçılar bu balığı yakalayabilmek için farklı türde çiğ balıkları ateşe yaklaştırırlar.";
        break;
      case "Shark":
        fish.fishName = "Köpek Balığı";
        fish.description = "Etçil balık. İsveç'ten gelir ve insanlık için feminenliğin ya da 'alan taraf' olmanın bir sembolü haline gelmiştir, fakat bu sembolün tam anlamı artık bilinmiyor.\n\nGeniş sularda yaşamayı sever, ama beslenmek için kıyıya yaklaştığı da görülmüştür.";
        break;
      case "Filthy Screaming Fish (Filsh)":
        fish.fishName = "Bağırgan Balık (Pislık)";
        fish.description = "Balık formunda manifest olmuş lanetlenmiş bir ruh. Ruhu aşırı güçsüz ve önemsiz olduğu için bunlara Kabuk bile denemez. Yapabildikleri tek şey sinir bozucu bir şekilde bağırmaktır.\n\nÇoğu zaman et yığınlarının içinde bulunurlar. Yanlarında ki herkes gibi kıyma olmaya mahkumlar.";
        break;
      case "Scraphead Fish":
        fish.fishName = "Hurdacı Balık";
        fish.description = "Bir makinenin balıkla buluşmuş formu. Akrabalarının aksine yüksek riskli çatışmalara girmez. Çevresinin sağladığı daha düşük ve daha güvenli bir yerel optimumla yetinir.\n\nÇevresini kaplayan hurda parçalarını kullanarak kendini güçlendirir ve sürekli et veren kıyma makinesinden beslenir. Görünüşü çoğu kişiye çirkin olsa da işin meraklılarına göre güzel bir görünüşe sahiptir; bu da pek çok taklitçinin ortaya çıkmasına neden olmuştur.";
        break;
      case "Wire Shark":
        fish.fishName = "Vâyırşark";
        fish.description = "Son derece enerji saçan bir balık olan bu canlı, yoluna çıkan her türlü zararlı veriyi yutar. Diğer türlere kıyasla daha zekilerdir ve hedeflerine ulaşmak için her zaman en kısa yolu kullanırlar.\n\nYüksek voltajlı endüstriyel alanlarda görülmeleri normaldir.";
        break;
      case "Overcooked Fish":
        fish.fishName = "Yanmış Balık";
        fish.description = "Fazla görülmeyen bir balık. Çoğu zaman lezzetli sanılsa da aslında kötü tadından dolayı insanlar tarafından tercih edilmezler.\n\nBüyük ihtimalle etçiller. Sadece aşırı sıcak suların içinde yaşarlar.";
        break;
      case "Coin":
        fish.fishName = "Sikke";
        fish.description = "Nadir ve fazlasıyla değerli bir balık. Aşırı pahalı ve değerli varlıkların takaslarında kullanıldığına bakarsak; insanlar için çok önemli bir yeri var gibi gözüküyor.\n\nSöylenene göre bir sikkeyi doğal yaşam alanına döndürürseniz sizin dileklerinizi gerçekleştirir.";
        break;
      case "Cancerous Fish":
        fish.fishName = "Kanserojen Balık";
        fish.description = "Mutasyona uğramış bir balık. Ağzından çıkan her kelimenin siyasetle alakalı olmasıyla ünlüdür. Hatta 1960'ların sonlarında Solcu ve Sağcı kavgasını başlattığı söylenir.\n\nSadece radyasyona mağruz kalmış suların içinde bulunur.";
        break;
      case "Flying Demon Fish":
        fish.fishName = "Kanatlı İblis Balığı";
        fish.description = "Tanrı'nın kendisine bir hakaret. O kadar iğrenç bir yaratık ki ne altındaki toprak, ne de üstündeki gökler onu kabul ediyor. Bu yüzden ikisi arasındaki soğuk ve acımasız rüzgârların ortasında savrulmaya mahkûm kalmış. Bu yaratık kendi yaratıcısı o iğrenç görünüşünden tiksindiği için bu azaba mahkûm edildiğine inanılıyor.\n\nAncak bu balık, yerli halk arasında bir lezzet olarak görülüyor. Cesur balıkçılar, genellikle yüksek rakımlı kayalıkların yakınlarında bu balığı yakalamak için hayatlarını tehlikeye atmaktadırlar.";
        break;
      case "Vapor Fish":
        fish.fishName = "Vapor Balığı";
        fish.description = "Teknoloji ile eski kültürün etkileşimi sonucu ortaya çıkan sentetik bir balık. Ancak geçmişe dair algısı yanlış ve çarpıktır.\n\nNeredeyse hiç balık bulunmayan bir şehrin kanallarında rastlanabilir; burada, eski kültürü bizzat deneyimleme fırsatı bulamamış, ancak yine de ona karşı bir özlem duyan sakinlerin dikkatini çeker.   ";
        break;
      case "Plastic Fish":
        fish.fishName = "Plastik Balık";
        fish.description = "Son derece nadir görülen, balık benzeri bir makine. Vücudunun büyük bir kısmı makinenin kendisi tarafından oluşturulan, ancak hiçbir pratik işlevi olmayan balık şeklindeki plastik bir kabuktan oluşur. Bu tür makinelerin çok azı bu standart dışı şekli tercih eder; ancak bu durum, saldırganlığa dair önemli bir azalma ile ilişkili olduğu görünmektedir.\n\nDoğası gereği çoğunlukla sakin bir hayvandır ve kanalizasyonlar da dahil olmak üzere binaların gözden uzak, ıssız bölgelerini tercih eder.";
        break;
      case "Koi Fish":
        fish.fishName = "Aynalı Sazan Balığı";
        fish.description = "Fazla görülmeyen bir balık. Efsaneye göre, bu balık bir şelaleyi yüzerek tırmanmayı başarırsa ejderhaya dönüşür. Lakin, ejderhalar gerçek olmadığı için bu imkansızdır.\n\nGöletlerde yüzmeyi sever. Hoşuna giden bir gölet bulursa, seçtiği o gölette 10 yıla kadar kalabilir.";
        break;
      case "Melted Fish":
        fish.fishName = "Erimiş Balık";
        fish.description = "Tuhaf bir görünüme sahip, son derece nadir bir balık.\n\nBu balığın nereden geldiği bilinmemektedir. Zira şimdiye kadar yalnızca kendisinden daha büyük hayvanların midelerinde bulunmuştur.";
        break;
      case "Ancient Fish":
        fish.fishName = "Antik Balık";
        fish.description = "Yaşadığı son derece zorlu ortam nedeniyle ortaya çıkan, insan yapımı bir balık. Efsanelere göre üzerine oyulmuş yazıtlar, çevresindeki anıtların yapım sürecini anlatıyor.\n\nKaynar suyu tercih eder.";
        break;
      case "Nerd Shark":
        fish.fishName = "İnek Köpek Balığı";
        fish.description = "Son derece okur yazar bir balık. Çok zeki. Yalnızca en seçkin edebi eserleri okur.\n\nKocaman su kütlelerinde yaşar ve dışarı çıkmaktan kaçınır; ancak daha fazla bilgelik arama acamıyla bazen kıyıya yakın yüzebilir.";
        break;
      case "Eel (?)":
        fish.fishName = "Yılanbalığı (?)";
        fish.description = "Dış görünüşü sert olan tuhaf bir yılanbalığı. Öfkeli tavırları nedeniyle acemi balıkçılar için aşırı tehlikeli bir türdür.\n\nBazen gemi enkazlarının yakınlarındago rastlanır.";
        break;
      case "Mannequin Fish":
        fish.fishName = "Manken Balığı";
        fish.description = "";
        break;
      case "Tasty Fish":
        fish.fishName = "Leziz Balık";
        fish.description = "Makineler arasında bir lezzet. Biyolojik yapısı nedeniyle doğal yaşam alanı dışında uzun süre hayatta kalamaz. Büyük rağbet gören bu balığı yetiştiren pek çok kişi vardır, ancak yetiştirenler genellikle şiddet eğilimli çatlak hırsızlarla çatışmaktadır.\n\nGenellikle geldiği yerin yakınlarında yüzerken görülmüştür.";
        break;
      case "Frozen Fish":
        fish.fishName = "Dondurulmuş Balık";
        fish.description = "Uzun ömürlü bir balık. Uzun süre çürümeden hayatta kalabilme konusundaki gizemli yeteneğiyle ün kazanmıştır.\n\nSadece aşırı soğuk sularda yaşar.";
        break;
      case "Metal(?) Fish":
        fish.fishName = "Metal(?) Balık";
        fish.description = "Metalden yapılmış bir göçmen balık.\n\nCehennemde yaşayan sapkın bir tür; başkalarının acı çekmesini izlemekten zevk alır. Dünyanın en acımasız balığı unvanı için en güçlü adaylardan biri.";
        break;
      case "\"size 2\"":
        fish.fishName = "\"boyut 2\"";
        fish.description = "Bir yalan. Tam bir sahtekarlık. Balıkçıları çılgına çevirmek için uydurulmuş bir aldatmaca. Birçoğu bu değersiz şeyi ararken boşuna canlarını kaybetti.\n\n<b><color=red>O L A N L A R D A N   M E M N U N   M U S U N</color></b>";
        break;
    }
    return fish;
  }

  public static void UnlockFish(FishObject fish) {
    if (!fishes.ContainsKey(fish.fishName)) {
      Plugin.logger.LogError($"Fish {fish.fishName} could not be found!");
      return;
    }

    // Plugin.logger.LogInfo($"Fish {fish.fishName} was found!");
    FishData fishData = fishes[fish.fishName];

    fishData.Unlock();
    UpdateSize2();
  }

  public static FishObject GetFish(string fishName) {
    return fishes[fishName].fish;
  }

  public static bool FoundFish(FishObject fish) {
    return fishes[fish.fishName].found;
  }

  public static FishCollection[] GetFishCollections() {
    return collections.ToArray();
  }

  public static string GetFishDescription(FishObject fish) {
    if (FoundFish(fish)) {
      return fish.description;
    }

    switch (fish.fishName) {
      case "null":
        return """"
Kesinlikle normal ve gerçek bir balık. Araf denen cennetin sakinlerinden.

Genellikle şelalenin altında yaşarlar.
"""";
      case "NaN":
        return """"
Huzurlu Araf katmanının mutlu sakinlerinin severek tükettiği yerel bir lezzet.

Genellikle suyun biriktiği yerlerde bulunur.
"""";
      case "Nil":
        return """"
Aşırı normal bir balık. Buna benzer balıkları her yerde bulabilirsin. Cennet gibi ve lüks Araf katmanında yaşar.

Genellikle suyun aktığı yerlerde bulunur.
"""";
      case "\"size 2\"":
        return """"
Herkesin bahsettiği efsanevi balık. Tüm balıkçıların hayali ama henüz kimse onu yakalayamadı. Söylendiğine göre, sadece her tür balığı yakalamış usta balıkçılara görünür.

Şelale, sukarıyı gizliyor. Agnes Gorge Yolu. Yeteneklerini kullan ve kaderini yerine getir.
"""";
      default:
        return fish.description;
    }
  }

  public static int Size2Chance() {
    if (collections[0].FoundAll() && collections[1].FoundAll()) return 1;
    else return 0;
  }

  public static void UpdateSize2() {
    if (SceneHelper.CurrentScene == "Level 7-S" && Size2Chance() == 1) {
      string path = "7-S_Unpaintable/Exterior/The Water Ups_Todo/The Water Ups/Water Ups Ocean";
      GameObject waterUpsOcean = GenericHelper.FindGameObject(path);
      if (waterUpsOcean == null) return;
      FakeWater fakeWater = waterUpsOcean.GetComponent<FakeWater>();
      if (fakeWater == null) return;
      FishDescriptor[] foundFishes = fakeWater.fishDB.foundFishes;
      foundFishes[0].chance = 1;
    }
  }
}
