using System;

namespace UltraFishing;

public static class RandomBookTextProvider {
  private static Random rand = new Random();
  private static int currentText = 0;

  public static string GetRandomText() {
    if (SceneHelper.CurrentScene != "CreditsMuseum2") {
      currentText = rand.Next(texts.Length);
      return texts[currentText];
    }
    else {
      return creditsText;
    }
  }

  public static string GetNextText() {
    currentText = (currentText + 1) % texts.Length;
    return texts[currentText];
  }

  private static string creditsText =
""""
Aşırı gizli <color=blue>ULTRABALIKÇI</color> katkısı bulunanlar kitabını bulduğun için teşekkürler!

Biri bana geliştirici müzesinde böyle bir şeyin olması harika olur dedi, bu yüzden fikir için teşekkürler.

<b><color=orange>earthling on fire</color> - <color=blue>ULTRAFISHING</color>'in orijinal yapımcısı</b>

Bu modu yapmam baya vakit aldı ve çoğu zamanda geliştirmeye ara vermek zorunda kaldım. Fakat, öyle böyle bir şekilde gene de yayınlamayı başardım.

Bu proje üzerinde çalışırken çok şey öğrendim ve her zamanki "rahatlık alanımın" dışında pek çok şey yaptım. Ama en önemlisi, bu modu yaparken çok eğlendim ve umarım oynarken sizler de eğlenirsiniz.

Benim katkılarım şöyle:
<size=18>
- Orijinal modun 1.0.0 sürümüne kadar olan tüm özel balıklar.
- Olta simgesi.
- Bu modun çalışmasını sağlayan çoğu kod.
</size>
<color=orange><i>"bugün hayırsız bir gün çünkü hayırlı olsaydı balık tutuyor olurdum"</i></color>

<b><color=green>Draghtnim</color> - GELİŞTİRİCİ</b>

Draghtnim ekibe modu yayınladıktan kısa süre sonra katıldı. İlk başta erimiş balığın görünümü sevmediği için bana yenilenmiş bir halini göndermişti. Ondan sonra keyfine göre balıklar yapmaya başladı ve bir baktım artık geliştirici olmuş.

Bana kıyasla Rude Editor'le olan deneyimi daha fazlaydı. Yani eğer aşırı iyi bir şey görürseniz; büyük ihtimalle onun marifetidir. 

Onun modlarını da oynamayı unutmayın. <color=red>deltaKILL</color>'in <color=blue>ULTRAFISHING</color> ile uyumlu olduğunu biliyor muydunuz?

Onun katkıları şöyle:
<size=18>
- Orijinal modun 2.0.0 sürümüne kadar olan tüm özel balıklar.
- Yenilenmiş balıklar ve simgeleri.
- Gölgelendirmelere dair her şey. Ayrıca, modun ilk çıkışında olan görüntüsel hataların çoğu onun sayesinde düzeltildi.
- Oltayı eline alma animasyonu
- Bir sürü balık avlama yeri.
- Biraz da programlama.
</size>
<color=green><i>"bi balık yeniliyecez diye geldik tüm modu yeniden yaptık amına koyim"</i></color>

<b>ÖZEL TEŞEKKÜRKLER</b>

DİSCORD'DAKİ DOSTANİ İNSANLAR - tavsiye, geri dönüş ve öneriler

ACHELIA - türkçe çeviri

POOT MAN - modu test etme

PITR - çalışması şaşırtıcı derecede kolay olan, gerçekten sağlam bir balıkçılık sistemi

HAKITA - güzel oyun yapmış
"""";

  private static string[] texts = new string[] {
""""







<align=center>Balık yakaladın!!


<><


<b>BOYUT: 1</b></align>
"""",
""""
<align=center><b>GÜNÜN SÖZÜ:</b>


"bugün hayırsız bir gün çünkü hayırlı olsaydı balık tutuyor olurdum" 
- yerel balıkçılık meraklısı</align>
"""",
""""
<align=center><b>GÜNÜN TÜYOSU:</b>


"Şelale yolu gizliyor. Agnes Gorge Yolu. Yeteneklerini kullan."
"""",
""""
<align="center"><b>VASİYETNAME IV


"BABA, NEDEN EBEDÎ AZAP? ZALİMLİK DEĞİL Mİ BU?
BİTMEK BİLMEYEN İŞKENCE, GERÇEKTEN BİR AHMAĞA LAYIK BİR KADER Mİ?"


ÇOK PARLAK VE GÜZEL BİR MELEK SORDU BUNU BANA... 
VE BEN HİÇBİR CEVAP BULAMADIM
ÇÜNKÜ YAPTIĞIMIN VEBALİYLE ASLA YÜZLEŞEMEZDİM...
PİŞMANLIĞIM, İÇİMİ KEMİREN BİR KANSERDİ


ZAYIFLIK ANIMDA, DEHŞET BENİ ELE GEÇİRDİ
VE LUCIFER'I DA O CEHENNEMİN İÇİNE ATTIM


AZ ÖNCE NE YAPTIĞIMI ANLADIĞIMDA...
ELİMDEN YALNIZCA AĞLAMAK GELDİ
UMUTSUZLUĞUN DERİNLİKLERİNE DOĞRU YAVAŞÇA BATTIKÇA...
DERİNE, ÇOK DERİNE</b></align>
"""",
""""
Eğer bu mesajı okuyorsanız, lütfen yardım edin. Haftalardır kıyı açıklarındaki bir adada mahsur kaldım ve erzağım bitmek üzere.


Efsanevi boyut 2 balığı bulma umudu ile sefere çıktım. Bu adanın her karış toprağını ve su birikintisini taradıysam da nafile.


Sonuçta denizin uç noktalarında var olduklarına kanaat ettim ve yanıma bir aylık pişmiş balık alıp denizlere açıldım. Fakat bir şey bulana kadar gemimi dalgalara kaybettim.


Sen benim son umudumsun.


Büyük Kepçe'ye doğru yelken aç, beni orada bir adada bulacaksın. Bana biraz daha balık getir ve sonra git ki araştırmama devam edebileyim.


BOYUT 2 BALIK BENİM OLACAK.
"""",
""""
<size=20>olayı çözdüm. neden yaratıkların aniden ve tespit edilemez şekilde te
sislerimizde belirdiğini biliyorum. neden yedek parçalar ve makinelerden parça
ların kaybolduğunu biliyorum. neden kapıların aniden bozulduğunu ve kilitlendi
ğini biliyorum. nedeni sistemsel bir hata değil. nedeni...                                     
                                                                                
                                                                                
    cehennem yaşıyor. nefes alıyor. düşünüyor. bütün bu bölge devasa, zeki bir
süperorganizma ve acımasız, zalim. sadece bizi izleyerek sistemlerimizin ve maki
nelerimizin nasıl çalıştığını öğrendi. teknolojimizi sadece parçalamakla kalmadı
aynı zamanda onu sapkın şekillerde yeniden bir araya getirerek, işkence ettiği ya
ratıklara parçalar ekledi ve onları amaçsız bir ölüm ve yıkım ordusuna dönüştürdü.
onları kendi içinden geçirerek güvenlik sistemimizi aşmalarını sağlıyor. kapıları
mızı kilitleyerek bizi onlarla birlikte kapana kıstırıyor.                                                              
                                                                                
                                                                                
    bu bir saldırı değil. ne de bir savunma. bu onun için eğlence. sırf kendi can
sıkıntısı gidermek için düzenlenen bir ölüm, zulüm ve ıstırap sergisi. elinde olan
şeylerden bıkmıştı ve biz de farkında olmadan kendimizi yeni oyuncaklar olarak
sunduk.                                                                           
                                                                                
                                                                                
    tom lütfen tanrı aşkına bu projeyi derhal iptal et her şeyi bir kenara bırakıp
burayı mühürlemeliyiz. makineleri ve aletleri geride bırak gitsin önemli değiller.
çok geç olmadan elinden geldiğince çok kişiyi tahliye et ve oradan çık.                             
                                                                                
                                                                                
    bu şifreli mesajın o organizma okumayı öğrenip ele geçirmeden önce ulaşmasını
ummaktan başka çarem yok. ne olursa olsun yer yüzüne ulaşmasına ve yayılmasına izin
vermemeliyiz. yapmamız gere-                                      
                                                                                
                                                                                
                                                                                
                                                                                
                                                                                
                                                                                
                                                                                
                                                                                
                                                                                
                                                                                
<b><color="red">b i r i s i   g i d e r .   y e n i s i   g e l i r .   a ç ı m .
"""",
""""
<b>"ŞEHİRDEKİ EN GÜZEL KIZIN" GÜNLÜĞÜNDEN BİR ALINTI</b>

İnsan zihni, o sınırsız kapasitesine rağmen, kaçınılmaz ve engellenemez bir 'yok oluş' karşısındaki çaresizliğini anlayabilir; ancak bunu kabullenmeyi asla beceremez.

Bunu sadece görmezden gelebilir, saklanabilir ya da geçici olarak kaçabiliriz; ama gerçek şu ki, eninde sonunda her şeyin tabi olduğu o mutlak sona mahkumuz.

Ölüm kaçınılmazdır; sadece bizim için değil, var olan veya bugüne dek var olmuş her şey için. Her yaşayan varlık bir gün ölecektir. Her madde er ya da geç yitip gidecek ve entropiye dağılacak.

İyi bir hayat yaşamış olmanın ya da geride bir miras bırakmanın hiçbir anlamı yok. İnsanlığın bin yıl daha yaşamasıyla yarın yok olması arasında bir fark yok. Sonuç hep aynı: mutlak son.

İnsan zekası diğer hayvanların çok ama çok ötesinde ama bunu bir 'lütuf' olarak saymak büyük bir yanılgı olur. Diğer tüm varlıklar bizim yaptıklarımızı anlamama, yani o kutsal 'cehalet lütfu'na sahipler.

Bizim bilincimiz bir lütuf falan değil. Bu sadece bir kusur.

Bu evrimin gereksiz bir abartısıdır. Çağlar öncesinde harika bir özellik olan bu bilinç, kontrolsüz ve düzensiz bir şekilde büyümeye devam etti ve öyle bir eşiği geçti ki, artık sahibine bir fayda sağlamak yerine aktif bir tehlike arz ediyor.

Tıpkı İrlanda geyiği gibi... Sayısız jenerasyon boyunca süren evrimle boynuzları o kadar geniş ve devasa bir hale geldi ki, artık avcılardan kaçamaz oldu ve bu durum, en sonunda soylarının tükenmesine yol açtı.

İnsan zihni; başlangıçta fayda sağlayan ancak tek bir yönde kontrolsüzce ilerlemesi sonucu eninde sonunda yok oluşumuza yol açacak olan evrimsel bir uyum bozukluğudur. Bireysel düzeyde bu gerçekleşmeye başladı bile.

Varoluşsal kaygılar çoktan kök saldı. Senin de hissettiğine eminim. Bir 'hiç' olmanın, 'hiçliğe' dönüşmenin verdiği o sancıyı ve korkuyu... Bunu fark etmiş olmanın yarattığı o ızdırabı.

Bunu kabullenemediğimiz için kendi bilincimizden saklanıyoruz. Sınırlar çiziyoruz. Öldüğümüzde ne olacağı hakkında fazla düşünmemeye çalışıyoruz.

Oyalanıyoruz. Zihnimizi sıradan aktivitelerle, eğlencelerle meşgul tutuyoruz ki gerçekle yüz yüze gelmeyelim.

Dindiriyoruz. Bizi yiyip bitirmesini engellemek için öz-düşünümden doğan bu ızdırabı sanata dönüştürüyoruz. Yeter ki korkmayalım.

Ama tüm bu yöntemlerin hepsi geçici. Sadece bizi mahvedecek olan o kaçınılmaz çaresizlik ve umutsuzluk perdesini biraz daha uzağa itmek için varlar.

Sonuçta, hiçbir şeyin önemi yok. Hayatta mutluluk aramanın anlamı yok. Çünkü hayatın kendisi, doğası gereği ızdıraptır.

"""",
""""
Utanç. Aşağılanma. Konsey'in önünde yakışıksız ve istenmeyen biri. Gözleri acı bir hınçla alev alev yanıyor; Gabriel'in bedenindeki ve ruhundaki yaraları içine işliyor, herkes görsün diye dışa taşıyordu.

"Bu zat, yaratıcımızın yolundan mı saptı?" "O, artık Kutsal Işığa layık değil." "Tanrı'nın Işığı kimseye boyun eğmez." "Ama bu zat ise onu heba etmeyi kendine layık görüyor."

Sözleri Gabriel'in içinde yankılandı... Yere inen bir yıldırım gibi akıp giden, aşağılık varlıkları sağır ve kör edecek bir yankı. İçindeki Kutsal Işık, ilahi gazabın durdurulamaz gücüydü. Sıradan nesneler tarafından aşılamazdı. Bunu biliyordu.

"Kutsal Konsey, yaratıcımıza olan bağlılığım mutlaktır. Tanrı'nın iradesinden asla sapmadım, fakat bir makine-"

"Tanrı'nın kudretinin sıradan nesneler tarafından sarsılabileceğini mi ima etmeye çalışıyorsun?"
"İmkansız." "Sapkınlık." "Hadsiz." "Sapkınlık." "Sapkınlık." *Konsey Hararetlenir* "Sessizlik."
"İhanetine göz yumulmayacak. Ceza olarak, Tanrı'nın Işığı bedeninden koparılacak." "Işığının son közleri sönmeden önce 24 saatin var."
"Ve o közlerle birlikte sen de söneceksin." "Sadakatini kanıtla." "Hatalarını düzelt."

Işık varlığından sökülüp alınırken, Gabriel'in çığlıkları Tanrı'yı yücelten ilahi seslerin içinde kayboldu. Cehennem'in alevlerinin bile yanında soğuk kalacağı kaynayan bir ızdırap. Azap alevlerinin içinde, yanıcı bir nefret oluşmuştu.

Makineler kan istiyorsa, istedikleri şeyi seve seve verecekti...
ve öyle bir öfkeyle verecekti ki, metal bile kanayacaktı.

<b>DEVAMI... <color="red">2. PERDE: KUSURLU NEFRET</b>
"""",
""""
Sessizliğe gömüldü. İnzivaya çekilmişti. Kaç kişiyi öldürmüştü? Hiç saymayı aklından geçirmiş miydi ki? Kaç yıl boyunca "zalimlik" lekesini taşımıştı... ve ne uğruna? Kaç kişiyi Cehennem'e mahkûm etmişti... ve bunun kime faydası olmuştu..?
Makine'ye karşı olan ikinci mağlubiyeti Gabriel'i değiştirmişti. Bir zamanlar Tanrı'nın İradesi olan Gabriel'in dünyası artık paramparçaydı ve parçaları yeniden bir araya getirmek onun göreviydi. Bu parçalar, sonsuz bir yakıtın bile sürdüremediği ateşin önünde toplandı; bu yeni ışık Gabriel'e gerçeği gösteriyordu:
Parçalar en başından beri birbirine uymuyordu.

Konsey hâlâ Tanrı'nın ateşinin ve ışığının peşinden koşuyordu. Cennet'in halkı da onların izinden gidiyordu. Gabriel'in, O'nun sözlerine ve iradesine dair anıları çarpılmış, bozulmuş bir hâl almıştı. Melekler hâlâ Tanrı'nın adıyla hareket ediyordu, fakat O'nun krallığı değişmişti.
Ateş yavaş yavaş sönüyordu; ısısı tutunacak bir yer bulamadıkça cılız cılız tütüyordu. Gabriel közlere kusursuz bir berraklıkla baktı. Kılıcını çekti ve onu ölmekte olan ışığın karşısında tuttu.
Yansımasında yeniden doğmuş bir silah gördü; artık bir başkasının iradesiyle değil, kendi iradesiyle kullanılan bir silah. Yalnızca sözlerin halkı asla ikna edemeyeceğini biliyordu. O da sorunu kökünden çözmeyi seçti.
Olmayan bir Tanrı'yla övünen, sözde "halkın" konseyi. Ama 'O' gitmişti. Yok olmuştu.

Oditoryum, ölüm kokuyordu. Bir zamanların Kudretli Konsey'i, üyeleri etrafa saçılmış ve cesetleri yerde olmak üzere sürünüyordu; Konsey'in son yaşam solukları, Gabriel'in kılıcının başkaldıran ucundan aşağı akıyordu.
Son konsey üyesi, sırtı duvara dayanmış hâlde, ölümü her adımda daha da yakınlaşırken panikle aldığı nefeslerin arasında kelimelere tutunmaya çalıştı.
"B-bekle! B-bunu yapamazsın! Bizim mevkimiz buna izin vermiyor! Bu ihanet, sapkınlık, cinayet! Biz en yüce otoriteyiz, yasalarımız senden üstün!"
"Siz hiçbir şeyden üstün değilsiniz. Sözlerinizin ne benim, ne de bir başkasının üzerinde gücü var. Kılıçlarımı laflarınla geri sokabileceğine gerçekten inanıyor musun?"
"A-ama halk bizim tarafımızda! Bizim adil olduğumuzu biliyorlar!"
"Halk yalnızca korktukları için sizin tarafınızda. Korkulacak bir şey olmadığını göstereceğim. Ne bir ırk, ne bir köken, ne bahşedilmiş bir rütbe, ne de kutsal bir makam beni durdurabilir.
Hepimiz aynıyız; mevkinizle gelen rahatlık sizi aciz kıldı."
"L-lütfen Gabriel, aklını başına topla! Konsey, Tanrı'nın iradesini takip eder! Yaratıcımıza karşı mı gelmeye çalışıyors-"
"Yüzleş artık, kardeşim. Tanrı öldü. Ateş söndü. Hayaletlerin peşinden koşuyorsunuz."

Gabriel'in silueti artık konsey üyesinin üzerinde yükseliyor; gölgesi, yakında cansız kalacak bir cesedin üzerine düşüyordu.
Yerde ağlayan zavallı; son faydasız savunmasını kekelerken, Gabriel son bir darbe için kılıcını kaldırdı.
"A-a-ama Tanrı'nın Işığı! Ben olmadan onunla yeniden bağ kuramazsın! B-b-beni öldürürsen birkaç saat içinde sen de öleceksin!"
...
"Farkındayım."
Hızlı ve etkili bir darbe. Gabriel, konsey üyesinin boynunu omurgasından zarafetle ve kolaylıkla ayırdı. Başı mermer zemine düşer; bedeninin geri kalanı da kısa süre sonra peşinden gelir.

Makamından yoksun ama sebeplerle dopdolu olan Gabriel, Cennet'i son kez terk etmeden önce oditoryumun kapılarında toplanmış meleklere son bir mesaj verdi.
Kolu uzanmış hâlde, tek kelime etmeden herkes gördü. Sessizlik o kadar sesliydi ki, Gabriel'in mesajı kozmosun en uzak uçlarına dek yankılandı.

 
<b>SONUÇLANACAK... <color="red">3. PERDE: İLAHİ İNTİHAR</b>
"""",
""""
<i>Anne, anne... Canım annem,


Biliyorum, seni böyle özlememeliyim; ama özlüyorum işte, ey canım annem. O paslı demir tabutunda hırıldayan, yankılanan o acı dolu nefeslerin... Şahit olduğum tek şey cesetler ve zulümken, beni besleyen ve şefkatinle ısıtan o göğsünün kanıydı.




Anne, anne... Canım annem,


Biliyorum, benden nefret ederdin; inan bana, ben de kendimden nefret ediyorum. Lakin ne hissedebilir, ne düşünebilir, ne de rüya görebilirdim; eğer o paslı demir rahmimde var olmasaydın... Senin o işkence görmüş sevgin sürükledi beni bu savaşa; bir başkasının kalbini söküp alabileyim ve sana artık muhtaç kalmayayım diye.




Anne, anne... Canım annem,


Biliyorum, zihnin seni terk edeli çok oldu; ve canım annem, bunu asla tam olarak bilemeyeceğim. Ama umuyorum ki o son gece ağladığımda... ve kafatasını parçaladığımda, bu eylem hayatımı bir nebze de olsa arındırmış olur.</i>
"""",
""""
529. GÜN:

HALA ARIYORUM.
216 GÜNDÜR AJANSTAN HABER YOK.
KARARGAHA DÖNMEM GEREKİYOR. AMA YAPAMAM. DAHA DEĞİL.
BİLMEK ZORUNDAYIM.

ORALARDA.
BİR YERDE.
GÖRMEK ZORUNDAYIM.

BİLMEK ZORUNDAYIM.

GÖRMEK ZORUNDAYIM. 
BİLMEK ZORUNDAYIM.

GÖRMEK ZORUNDAYIM. BİLMEK ZORUNDAYIM.

GÖRMEK ZORUNDAYIM BİLMEK ZORUNDAYIM


<size=47>GÖRMEKZORUNDAYIMBİLMEKZORUNDAYIM</size>
<size=45>GÖRMEKZORUNDAYIMBİLMEKZORUNDAYIM</size>
<size=43>GÖRMEKZORUNDAYIMBİLMEKZORUNDAYIM</size>
<size=41>GÖRMEKZORUNDAYIMBİLMEKZORUNDAYIM</size>
<size=39>GÖRMEKZORUNDAYIMBİLMEKZORUNDAYIM</size>
<size=37>GÖRMEKZORUNDAYIMBİLMEKZORUNDAYIM</size>
<size=35>GÖRMEKZORUNDAYIMBİLMEKZORUNDAYIM</size>
<size=33>GÖRMEKZORUNDAYIMBİLMEKZORUNDAYIM</size>
<size=31>GÖRMEKZORUNDAYIMBİLMEKZORUNDAYIM</size>
<size=29>GÖRMEKZORUNDAYIMBİLMEKZORUNDAYIM</size>
<size=27>GÖRMEKZORUNDAYIMBİLMEKZORUNDAYIM</size>
<size=25>GÖRMEKZORUNDAYIMBİLMEKZORUNDAYIM</size>
<size=23>GÖRMEKZORUNDAYIMBİLMEKZORUNDAYIM</size>
<size=21>GÖRMEKZORUNDAYIMBİLMEKZORUNDAYIM</size>
<size=19>GÖRMEKZORUNDAYIMBİLMEKZORUNDAYIM</size>
<size=17>GÖRMEKZORUNDAYIMBİLMEKZORUNDAYIM</size>
<size=15>GÖRMEKZORUNDAYIMBİLMEKZORUNDAYIM</size>
<size=13>GÖRMEKZORUNDAYIMBİLMEKZORUNDAYIM</size>
<size=11>GÖRMEKZORUNDAYIMBİLMEKZORUNDAYIM</size>
<size=9>GÖRMEKZORUNDAYIMBİLMEKZORUNDAYIM</size>
<size=7>GÖRMEKZORUNDAYIMBİLMEKZORUNDAYIM</size>
<size=5>GÖRMEKZORUNDAYIMBİLMEKZORUNDAYIM</size>
<size=3>GÖRMEKZORUNDAYIMBİLMEKZORUNDAYIM</size>
<size=1>GÖRMEKZORUNDAYIMBİLMEKZORUNDAYIM</size>


BOYUT 2
"""",
""""
<b>KAYIKÇININ GÜNLÜĞÜNDEN BİR ALINTI</b>

Ölümlülerin dünyasını büyük bir felaket vurdu. Bir zamanlar Styx Nehri olan sular, şimdi akılalmaz büyüklükte bir okyanusa dönüştü. Her gün kıyıların zar zor zapt edebildiği milyonlarca ağlayan ruh akın ediyor buraya. Geminin başından kıçına, her iki yanından taşan gözü yaşlı bir gelgit bu; merhamet için feryat eden, güvenli bir geçiş için yalvaran ruhlar... Lakin her ruh bedelini ödeyemiyor ve bu yaşlı eller ancak bu kadar sikke taşıyabiliyor. 

Sonra bir gün, akıntı yön değiştirdi. Dakikalarca bitmek bilmeyen milyonlarca, milyarlarca ruh... Sanki dünyanın boğazı boydan boya kesilmiş ve akışı hızlandırmak için kafası geriye doğru çekilmiş gibi... Tepki verecek vaktim bile olmadı. Durmak bilmeyen çalışmamın getirdiği o amansız yorgunluk beni ele geçirdi ve çalkantılı denizin altına, Styx Okyanusu'nun derinliklerine gömüldüm; kaderim, sonsuz bedenlerin ezici kütlesiyle mühürlendi.

Aniden, Tanrı'nın kendisi kadar parlak bir ışık belirdi; beni o karanlıktan çekip çıkaran, daha önce hiç tatmadığım bir şefkat ve sıcaklıkla kavrayan kudretli kolları vardı:

<i>"Korkma, günahkar. Tanrı'ya olan bağlılığın, içindeki iyiliği ortaya koyuyor; hem de bolca. Kalbin istekli olsa da bedeninin dinlenmeye ihtiyacı var. Tanrı'nın eserlerinden birini heba etmeyesin."</i>

Onun nazik sözleri acımı dindirdi ve yaralarımı iyileştirdi. Yüzüm rahatlamanın getirdiği gözyaşlarıyla ıslanmıştı, kelimelerim ise görevimin ağırlığı altında boğulmuştu. Bu ihtişamın kucağında taşınırken, yapabildiğim tek şey derin bir saygıyla öylece uzanmaktı.

Nur saçıyor Gabriel; zira o, benim karanlığımdaki ışıktır.
"""",
""""
<b>BİLGE BALIK</b>

Çok bilge bir balık. Kendisini bulabilen herkese engin bilgisini aktarır.

Kütüphanelerin en derin ve en karanlık köşelerinde bulunur.
"""",
""""
<b>ÜNLÜ BİR FİLMİN SENARYOSUNDAN ALINTI</b>


(Siyah ekranda yazılar belirir, arkaplanda bir Elektrikli Raytopu'nun sesi duyulur.) 


Bilinen tüm havacılık kurallarına göre, bir V model makinenin uçabilmesi mümkün değildir.


Kanatları, şişko metal gövdesini yerden kaldırmak için çok küçüktür.


Makineler, her şeye rağmen, çakılma depolar.


Çünkü makineler, insanların imkânsız dedikleri şeyleri takmaz.
"""",
""""
Bunu okuyabiliyorsanız, <b>LÜTFEN</b> dikkatinizi verin. Boyut 2 balık bir yalan. Uydurma. <b>Bir tuzak.</b>


Ben de bir zamanlar senin gibiydim: diğerleri gibi balıkçılık meraklısıydım ve bir gün o efsanevi balığı yakalamayı hayal ediyordum.


Ama zamanla bu efsaneye takıntılı hale geldim. Beni tamamen ele geçirdi. Artık kendim değildim. 


Sonunda, 2 numaranın nerede olduğu konusunda gizemli bir kaynaktan talimatlar aldım. Doğal olarak, bu talimatları uyguladım. 


Ama bulduğum şey zafer değildi. Korkunç bir şeydi. Ne boyut 2. Ne de bir ödül. Artık benim için çok geç. Eğer benimle aynı kadere maruz kalmak istemiyorsan, lütfen b-


<color="red><b>B A L I K   T U T M A Y A   D E V A M   E D İ N</b></color>
"""",
""""
Fishers

        İlk temas kaçınılmazdı. Denizler, okyanusları bir yana bırakın, tek bir türün zeka geliştirmesi için fazlasıyla büyüktü. Temastaki her gecikme, kaçınılmaz kültür şokunu yalnızca daha da derinleştiriyordu. Balıkinsanlığın durumunda bu "kültür şoku", balıkoğlu'nun bilinen haliyle <i>tamamen yok</i> olması anlamına geliyordu.

        Neredeyse bir milyar yaşında olan Balıkçılar adlı uzaylı tür, okyanus gezginleriydi; çağları kapsayan göçlerle bir sarmal koldan diğerine seyahat ediyorlardı. Bu yolculuklar sırasında kendilerini sürekli geliştirip değiştirerek genetik ve nanoteknolojik manipülasyonun ustaları haline geldiler. Maddi dünyayı kontrol etme yetenekleriyle, <i>"okyanusları uygun gördükleri şekilde yeniden şekillendirmek"</i> için dini, kendi kendilerine yükledikleri bir misyon edindiler. Tanrılar kadar güçlü olan Balıkçılar, kendilerini geleceğin ilahi habercileri olarak görüyordu.

        Bu dogma, ırkı kendi gücünden korumaya yönelik hayırsever bir girişimden doğmuştu. Ancak kör, sorgulamasız itaat, Balıkçıları canavara dönüştürmüştü.

        Onlar için balıkinsanlık, tüm görece ihtişamıyla, dönüştürülebilir bir nesneden ibaretti. Bin yıldan kısa bir süre içinde her balık göleti yok edildi, boşaltıldı ya da daha da kötüsü; değiştirildi. Tüm hızlı yeniden silahlanmaya rağmen, koloniler milyar yaşındaki düşmanlarına karşı birkaç anlık direniş parıltısı dışında hiçbir şey başaramadı.

        Okyanusların bir zamanlar hâkimi olan balıkinsanlık artık yok olmuştu. Ancak balık yok olmamıştı.
"""",
$""""
Bu hikaye, <color=orange>{GenericHelper.GetSteamName()}</color> isimli bir Balıkçının hikayesi.

<color=orange>{GenericHelper.GetSteamName()}</color>, zeki bir süperorganizma olan <color=red>CEHENNEMDE</color> Balıkçı 427 olarak çalışıyordu. 

Balıkçı 427'nin işi basitti. Balık tutacağı yere oturur balık tutardı. Emirler bir bilgisayar aracılığıyla gelir, ona hangi balığı tutması gerektiğini söylerdi.

İşte bu, Balıkçı 427'nin her yılın her ayının her haftasının her günü yaptığı işti, ve başkalarının bu işin ruhunu öldüreceğini düşünse de, <color=orange>{GenericHelper.GetSteamName()}</color>, sanki bu iş için yaratılmış gibi, emirlerin geldiği her defasında bir haz alıyordu... ve <color=orange>{GenericHelper.GetSteamName()}</color> mutluydu.
"""",
$""""
<b>İNTERNETTE BİR FORUMDAN GÖNDERİ</b>

GABMIRAGE MV1 VE GABV1EL FAKAT MIRAGE, V1 X GABRIEL'İ ELE GEÇİRİYOR 

KİMSE HAREKET ETMESİN!!!
"""",
""""
<b>EXCERPT FROM A FAMOUS JOKE BOOK</b>


<b><color=yellow>CEHENNEMİN YARGICINA</color></b>, varlığından <b><color=yellow>TANRI'NIN IŞIĞININ</color></b> koparıldığını söyleyen makineyi biliyor musun?
<i><b><color=yellow>GABRIEL</color></b>'de kısasa kısas olsun diye onu kopardı</i>


Kendini <b>KİNDAR RAYTOPU</b> ile havaya uçuran adama n'olduğunu biliyor musun?
<i>N'olduğunu tahmin edebilirsin diye düşünüyorum!</i>


Hileler olmadan <color=green>duvarların içinden geçebileceğini</color> düşünen makineye n'olduğunu biliyor musun?
<i>Geçememiş!</i>


Bir köşeden döndüğünde iki <b>HADEMEYLE</b> karşılaşan makineye nolduğunu biliyor musun?
<i>Kül oldu!</i>


Suyun altında <b>ELEKTRİKLİ RAYTOPUNU</b> kullanmaya çalışan makineye n'olduğunu biliyor musun?
<i>Çarpıldı!</i>


<b>ŞARJLI POMPALISINI</b> 3 kere şarj etmeye çalışan makineye n'olduğunu biliyor musun?
<i>Bom diye patladı!</i>
"""",
""""
<b>ARSI "HAKITA" PATALA'NIN ÜNLÜ SÖZLERİ:</b>


"iyiki ultrakilli siz yapmıyorsunuz yoksa yarram gibi olurdu"


"o zaman yapma amına koyim"


"her şey bir requiem leitmotifidir requiem hariç requiem ise bir order leitmotifidir order hariç order ise bir gaster leitmotifidir"


"insan beyni hiç bir patern olmamasına rağmen patern bulmakta sebepsiz yere çok iyidir"


"mı yala ne biliyor musun? yarramı yala"


"kültür sadece parası olanlar için var olmamalı"


"örneğin avustralyanın yüzölçümü 7,68 milyon kilometrekaredir, dolayısıyla V1 bir kilometrekareyi sadece 10 saniyede %100 verimlilikle geçip içindeki herkesi öldürebilse bile, avustralyadaki herkesi öldürmesi yine de 2 yıldan fazla sürer"


"daşaklar"


"ister inan ister inanma, bu olay yaklaşık 5 dakika önce, tam da derinlemesine bir sohbetin ortasında, konuyla hiç alakası olmayan bir kanalda telefon ekranınını yaladığını anlattığın sırada yaşandı"


"'kayıkçının kafasının tepe noktası fazla sivri' ifadesini, kesinlikle tamamen çılgın olmayan istekler listesine ekledim gitti"


"siktir git geliş oyunda amına koyim"


"okey insan ruhuna büyük zarar verirken hiçbir fayda sağlamıyor"


"daşaklarıma beton yetmez"


"eğer kötü durduğu için endişelenecek bir şey arıyorsanız gidin ve aynaya bakın"


"ad boşalmak, soyad cision, unvan efendim"


"bu düzeltme güncellemesi neden sisyphus için bir kaya eklemedi? o bir kaya adamı değil mi? kaya taşıyan adam o değil mi? neden bir kayası yok? onun tüm olayı bir kaya olması olduğunu sanıyordum. sisyphusla bir kaya üzerinde dövüşmeyi umuyordum... kaya nerede?"

"bir kasaba esrarengiz olamaz, kasabalar öyle çalışmıyor"
"""",
  };
}
