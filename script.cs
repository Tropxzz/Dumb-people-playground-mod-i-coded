using System;
using UnityEngine;

namespace Mod
{
    public class Mod
    {
        public static void Main()
        {
            // Create a new category for the mod items
            CategoryBuilder.Create("Random Mod", "So pro for some reason", ModAPI.LoadSprite("ModStuff/pixil-frame-0 (2).png"));

            // Register a modified knife
            ModAPI.Register(new Modification()
            {
                OriginalItem = ModAPI.FindSpawnable("Knife"),
                NameOverride = "Knife I terribly made",
                DescriptionOverride = "Knife with different Texture.",
                CategoryOverride = ModAPI.FindCategory("Random Mod"),
                ThumbnailOverride = ModAPI.LoadSprite("Thumbnails/Knife Thumbnail.jpg"),
                AfterSpawn = (Instance) =>
                {
                    Instance.GetComponent<SpriteRenderer>().sprite = ModAPI.LoadSprite("Sprites/Knife Sprite.png");
                    Instance.FixColliders();
                }
            });

            // Register another modified knife with a different texture
            ModAPI.Register(new Modification()
            {
                OriginalItem = ModAPI.FindSpawnable("Knife"),
                NameOverride = "Normal Sized Foosh",
                DescriptionOverride = "Damn we're playing with humans that are smaller, craaaaaaaaaaaaaaaaazy.",
                CategoryOverride = ModAPI.FindCategory("Random Mod"),
                ThumbnailOverride = ModAPI.LoadSprite("Thumbnails/electric-floppy-fish-toy-moving-cat-kicker-fish-toy-11-realistic-flopping-fish-dog-toy.png"),
                AfterSpawn = (Instance) =>
                {
                    Instance.GetComponent<SpriteRenderer>().sprite = ModAPI.LoadSprite("Sprites/Knife.png");
                    Instance.FixColliders();
                }
            });

            // Register a bike horn attachment
            ModAPI.Register(
                new Modification()
                {
                    OriginalItem = ModAPI.FindSpawnable("Scope Attachment"), // derive from an attachment
                    NameOverride = "Bike Horn",
                    NameToOrderByOverride = "zzzzzhorn",
                    DescriptionOverride = "A bike horn that goes on the top of a gun. Does what you think it does. Attaches to the scope attachment point.",
                    CategoryOverride = ModAPI.FindCategory("Random Mod"),
                    ThumbnailOverride = ModAPI.LoadSprite("Thumbnails/BikeHornThing.png"),
                    AfterSpawn = (Instance) =>
                    {
                        // give the attachment a new sprite
                        Instance.GetComponent<SpriteRenderer>().sprite = ModAPI.LoadSprite("Sprites/bikehorn.png");
                        Instance.FixColliders();

                        // while you can use a new sound for the connection sound, you can do this to keep the current sound
                        // each attachment can have a unique connection sound
                        AudioClip attach = Instance.GetComponent<ScopeAttachmentBehaviour>().ConnectClip;

                        // destroy the existing attachment behaviour
                        UnityEngine.Object.Destroy(Instance.GetComponent<ScopeAttachmentBehaviour>());

                        // add the new attachment behaviour (unless it already exists)
                        var attachment = Instance.GetOrAddComponent<BikeHornAttachmentBehaviour>();

                        // set the connection sound
                        attachment.ConnectClip = attach;

                        // here is some other stuff you can change
                        attachment.AttachmentType = FirearmAttachmentType.AttachmentType.Scope; // whether the attachment will connect to the top or bottom of the gun
                        attachment.AttachmentOffset = Vector2.zero; // the offset from the attachment point (generally only used if you want the sprite to be within the gun and stuf

                        // setting the new audio clip
                        attachment.HornNoise = ModAPI.LoadSound("Sounds/bicycle-horn-7126.mp3");
                    }
                }
            );


            // Register a nuclear foosh bomb
            ModAPI.Register(new Modification()
            {
                OriginalItem = ModAPI.FindSpawnable("General Purpose Bomb"),
                NameOverride = "Nuclear Foosh",
                DescriptionOverride = "So pro",
                CategoryOverride = ModAPI.FindCategory("Random Mod"),
                ThumbnailOverride = ModAPI.LoadSprite("Thumbnails/electric-floppy-fish-toy-moving-cat-kicker-fish-toy-11-realistic-flopping-fish-dog-toy.png"),
                AfterSpawn = (Instance) =>
                {
                    Instance.GetComponent<SpriteRenderer>().sprite = ModAPI.LoadSprite("Sprites/Foosh.png");
                    ExplosiveBehaviour explobehaviour = Instance.GetComponent<ExplosiveBehaviour>();
                    explobehaviour.Range = 150f;
                    explobehaviour.Delay = 0f;
                    Instance.FixColliders();
                }
            });

            // Register a custom human called Isaiah
            ModAPI.Register(new Modification()
            {
                OriginalItem = ModAPI.FindSpawnable("Human"),
                NameOverride = "Isaiah",
                DescriptionOverride = "A Male Human Specimen from ________",
                CategoryOverride = ModAPI.FindCategory("Random Mod"),
                ThumbnailOverride = ModAPI.LoadSprite("Thumbnails/Isaiah.png"),
                AfterSpawn = (Instance) =>
                {
                    var skin = ModAPI.LoadTexture("Thumbnails/Isaiah.png");
                    var flesh = ModAPI.LoadTexture("Human Stuff/flesh layer.png");
                    var bone = ModAPI.LoadTexture("Human Stuff/bone layer.png");
                    var person = Instance.GetComponent<PersonBehaviour>();
                    person.SetBodyTextures(skin, flesh, bone, 1);
                    person.SetBruiseColor(86, 62, 130);
                    person.SetSecondBruiseColor(154, 0, 7);
                    person.SetThirdBruiseColor(207, 206, 120);
                    person.SetRottenColour(202, 199, 104);
                    person.SetBloodColour(108, 0, 4);
                }
            });

            ModAPI.Register(new Modification()
            {
                OriginalItem = ModAPI.FindSpawnable("Human"),
                NameOverride = "DUDE MAN!",
                DescriptionOverride = "Some random dude with a nice texture",
                CategoryOverride = ModAPI.FindCategory("Random Mod"),
                ThumbnailOverride = ModAPI.LoadSprite("Sprites/Prooo.png"),
                AfterSpawn = (Instance) =>
                {
                    var skin = ModAPI.LoadTexture("Sprites/Prooo.png");
                    var flesh = ModAPI.LoadTexture("Human Stuff/flesh layer.png");
                    var bone = ModAPI.LoadTexture("Human Stuff/bone layer.png");
                    var person = Instance.GetComponent<PersonBehaviour>();
                    person.SetBodyTextures(skin, flesh, bone, 1);
                    person.SetBruiseColor(86, 62, 130);
                    person.SetSecondBruiseColor(154, 0, 7);
                    person.SetThirdBruiseColor(207, 206, 120);
                    person.SetRottenColour(202, 199, 104);
                    person.SetBloodColour(108, 0, 4);
                }
            });

            ModAPI.Register(new Modification()
            {
                OriginalItem = ModAPI.FindSpawnable("Human"),
                NameOverride = "Isaiah Remaster",
                DescriptionOverride = "A Male Human Specimen from ________",
                CategoryOverride = ModAPI.FindCategory("Random Mod"),
                ThumbnailOverride = ModAPI.LoadSprite("Sprites/IsaiahRemaster.png"),
                AfterSpawn = (Instance) =>
                {
                    var skin = ModAPI.LoadTexture("Sprites/IsaiahRemaster.png");
                    var flesh = ModAPI.LoadTexture("Human Stuff/flesh layer.png");
                    var bone = ModAPI.LoadTexture("Human Stuff/bone layer.png");
                    var person = Instance.GetComponent<PersonBehaviour>();
                    person.SetBodyTextures(skin, flesh, bone, 1);
                    person.SetBruiseColor(86, 62, 130);
                    person.SetSecondBruiseColor(154, 0, 7);
                    person.SetThirdBruiseColor(207, 206, 120);
                    person.SetRottenColour(202, 199, 104);
                    person.SetBloodColour(108, 0, 4);
                }
            });


            // Register another custom human called Rock with a bikini
            ModAPI.Register(new Modification()
            {
                OriginalItem = ModAPI.FindSpawnable("Human"),
                NameOverride = "Rock with a bikini",
                DescriptionOverride = "sob",
                CategoryOverride = ModAPI.FindCategory("Random Mod"),
                ThumbnailOverride = ModAPI.LoadSprite("Sprites/pro.png"),
                AfterSpawn = (Instance) =>
                {
                    var skin = ModAPI.LoadTexture("Sprites/pro.png");
                    var flesh = ModAPI.LoadTexture("Human Stuff/flesh layer.png");
                    var bone = ModAPI.LoadTexture("Human Stuff/bone layer.png");
                    var person = Instance.GetComponent<PersonBehaviour>();
                    person.SetBodyTextures(skin, flesh, bone, 1);
                    person.SetBruiseColor(86, 62, 130);
                    person.SetSecondBruiseColor(154, 0, 7);
                    person.SetThirdBruiseColor(207, 206, 120);
                    person.SetRottenColour(202, 199, 104);
                    person.SetBloodColour(108, 0, 4);
                }
            });

            // Register another custom human called Elijah
            ModAPI.Register(new Modification()
            {
                OriginalItem = ModAPI.FindSpawnable("Human"),
                NameOverride = "Elijah",
                DescriptionOverride = "A Male Human Specimen from ________",
                CategoryOverride = ModAPI.FindCategory("Random Mod"),
                ThumbnailOverride = ModAPI.LoadSprite("Sprites/Untitled-removebg-preview (1).png"),
                AfterSpawn = (Instance) =>
                {
                    var skin = ModAPI.LoadTexture("Sprites/Untitled-removebg-preview (1).png");
                    var flesh = ModAPI.LoadTexture("Human Stuff/flesh layer.png");
                    var bone = ModAPI.LoadTexture("Human Stuff/bone layer.png");
                    var person = Instance.GetComponent<PersonBehaviour>();
                    person.SetBodyTextures(skin, flesh, bone, 1);
                    person.SetBruiseColor(86, 62, 130);
                    person.SetSecondBruiseColor(154, 0, 7);
                    person.SetThirdBruiseColor(207, 206, 120);
                    person.SetRottenColour(202, 199, 104);
                    person.SetBloodColour(108, 0, 4);
                }
            });

            // Register a custom pistol called Gun Agent 47 uses
            ModAPI.Register(new Modification()
            {
                OriginalItem = ModAPI.FindSpawnable("Pistol"),
                NameOverride = "Gun Agent 47 uses",
                DescriptionOverride = "pew pew",
                CategoryOverride = ModAPI.FindCategory("Random Mod"),
                ThumbnailOverride = ModAPI.LoadSprite("Sprites/@freeroboxgenerator is einstein.png"),
                AfterSpawn = (Instance) =>
                {
                    Instance.GetComponent<SpriteRenderer>().sprite = ModAPI.LoadSprite("Sprites/@freeroboxgenerator is einstein.png");
                    var firearm = Instance.GetComponent<FirearmBehaviour>();
                    Cartridge customCartridge = ModAPI.FindCartridge("9mm");
                    customCartridge.name = "7.63×25mm Mauser";
                    customCartridge.Damage *= 1f;
                    customCartridge.StartSpeed *= 5f;
                    customCartridge.PenetrationRandomAngleMultiplier *= 0.5f;
                    customCartridge.Recoil *= 2f;
                    customCartridge.ImpactForce *= 2f;
                    firearm.Cartridge = customCartridge;
                    firearm.ShotSounds = new AudioClip[]
                    {
                        ModAPI.LoadSound("Sounds/Gun Shot 1.wav"),
                        ModAPI.LoadSound("Sounds/Gun Shot 2.wav")
                    };
                    Instance.FixColliders();
                }
            });

            // Register an explosion rod
            ModAPI.Register(new Modification()
            {
                OriginalItem = ModAPI.FindSpawnable("Rod"),
                NameOverride = "Explosion",
                DescriptionOverride = "BANG",
                CategoryOverride = ModAPI.FindCategory("Random Mod"),
                ThumbnailOverride = ModAPI.LoadSprite("ModStuff/pixil-frame-0 (2).png"),
                AfterSpawn = (Instance) =>
                {
                    Instance.GetComponent<SpriteRenderer>().sprite = ModAPI.LoadSprite("ModStuff/pixil-frame-0 (2).png");
                    Instance.AddComponent<ExplosionThing>();
                    Instance.FixColliders();
                }
            });
        }
    }

    public class BikeHornAttachmentBehaviour : FirearmAttachmentBehaviour
    {
        public AudioClip HornNoise;

        public override void OnConnect() { }

        public override void OnDisconnect() { }

        public override void OnFire()
        {
            PhysicalBehaviour.PlayClipOnce(HornNoise, volume: 2.5f);
        }

        public override void OnHit(BallisticsEmitter.CallbackParams args) { }
    }

    public class ExplosionThing : MonoBehaviour
    {
        private void Start()
        {
            ExplosionCreator.CreateFragmentationExplosion(
                32,
                transform.position,
                4,
                7,
                true,
                false,
                0.5f);
        }
    }
}
