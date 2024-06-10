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
/*
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
*/

            ModAPI.Register(new Modification()
            {
                OriginalItem = ModAPI.FindSpawnable("Human"),
                NameOverride = "DUDE MAN!",
                DescriptionOverride = "Some random dude that is also a alien",
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
                    person.SetRottenColour(0,255,0);
                    person.SetBloodColour(0,255,0);
                }
            });

            ModAPI.Register(new Modification()
            {
                OriginalItem = ModAPI.FindSpawnable("Human"),
                NameOverride = "Isaiah",
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

            ModAPI.Register(new Modification()
            {
                OriginalItem = ModAPI.FindSpawnable("Human"),
                NameOverride = "Elijah",
                DescriptionOverride = "A Male Human Specimen from ________",
                CategoryOverride = ModAPI.FindCategory("Random Mod"),
                ThumbnailOverride = ModAPI.LoadSprite("Sprites/pleasework.png"),
                AfterSpawn = (Instance) =>
                {
                    var skin = ModAPI.LoadTexture("Sprites/pleasework.png");
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
                NameOverride = "Elijah",
                DescriptionOverride = "A Male Human Specimen from ________",
                CategoryOverride = ModAPI.FindCategory("Random Mod"),
                ThumbnailOverride = ModAPI.LoadSprite("Sprites/pleasework.png"),
                AfterSpawn = (Instance) =>
                {
                    var skin = ModAPI.LoadTexture("Sprites/pleasework.png");
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
                NameOverride = "Zeke",
                DescriptionOverride = "A Male Human Specimen from ________",
                CategoryOverride = ModAPI.FindCategory("Random Mod"),
                ThumbnailOverride = ModAPI.LoadSprite("Sprites/zeke.png"),
                AfterSpawn = (Instance) =>
                {
                    var skin = ModAPI.LoadTexture("Sprites/zeke.png");
                    var flesh = ModAPI.LoadTexture("Human Stuff/flesh layer.png");
                    var bone = ModAPI.LoadTexture("Human Stuff/bone layer.png");
                    var person = Instance.GetComponent<PersonBehaviour>();
                    person.SetBodyTextures(skin, flesh, bone, 1);
                    person.SetBruiseColor(86, 62, 130);
                    person.SetSecondBruiseColor(154, 0, 7);
                    person.SetThirdBruiseColor(207, 206, 120);
                    person.SetRottenColour(202, 199, 104);
                    person.SetBloodColour(108, 0, 4);

                    var head = Instance.transform.GetChild(5);
                    var childObject = new GameObject("Helmet");
                    childObject.transform.SetParent(head);
                    childObject.transform.localPosition = new Vector3(0f, 0.25f);
                    childObject.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
                    childObject.transform.localScale = new Vector3(1f, 1f);
                    var childSprite = childObject.AddComponent<SpriteRenderer>();
                    childSprite.sprite = ModAPI.LoadSprite("Sprites/zeketophalf.png");
                    childSprite.sortingLayerName = "Bottom";
                }
            });

            ModAPI.Register(new Modification()
            {
                OriginalItem = ModAPI.FindSpawnable("Revolver"),
                NameOverride = "Isaiah's Revolver",
                DescriptionOverride = "Isaiah's Beautiful Revolver",
                CategoryOverride = ModAPI.FindCategory("Random Mod"),
                ThumbnailOverride = ModAPI.LoadSprite("Thumbnails/Revolver.png"),
                AfterSpawn = (Instance) =>
                {
                    Instance.GetComponent<SpriteRenderer>().sprite = ModAPI.LoadSprite("Sprites/revovler.png");
                    Instance.FixColliders();
                }
            });

            ModAPI.Register(new Modification()
            {
                OriginalItem = ModAPI.FindSpawnable("Shotgun"),
                NameOverride = "Elijah's Shotgun",
                DescriptionOverride = "ChopStick Shotgun?",
                CategoryOverride = ModAPI.FindCategory("Random Mod"),
                ThumbnailOverride = ModAPI.LoadSprite("Sprites/shotgunchopstickthing.png"),
                AfterSpawn = (Instance) =>
                {
                    Instance.GetComponent<SpriteRenderer>().sprite = ModAPI.LoadSprite("Sprites/shotgunchopstickthing.png");
                    Instance.FixColliders();
                }
            });


            ModAPI.Register(new Modification()
            {
                OriginalItem = ModAPI.FindSpawnable("Assault Rifle"),
                NameOverride = "My AR-15",
                DescriptionOverride = "Pro",
                CategoryOverride = ModAPI.FindCategory("Random Mod"),
                ThumbnailOverride = ModAPI.LoadSprite("Sprites/AR-15.png"),
                AfterSpawn = (Instance) =>
                {
                    Instance.GetComponent<SpriteRenderer>().sprite = ModAPI.LoadSprite("Sprites/AR-15.png");
                    Instance.FixColliders();
                }
            });

            ModAPI.Register(new Modification()
            {
                OriginalItem = ModAPI.FindSpawnable("Minigun"),
                NameOverride = "Zeke's Minigun",
                DescriptionOverride = "A minigun with a fedora?",
                CategoryOverride = ModAPI.FindCategory("Random Mod"),
                ThumbnailOverride = ModAPI.LoadSprite("Sprites/FedoraMinigun.png"),
                AfterSpawn = (Instance) =>
                {
                    Instance.GetComponent<SpriteRenderer>().sprite = ModAPI.LoadSprite("Sprites/FedoraMinigun.png");
                    Instance.FixColliders();
                }
            });



            // Register another custom human called Rock with a bikini
            ModAPI.Register(new Modification()
            {
                OriginalItem = ModAPI.FindSpawnable("Human"),
                NameOverride = "Rock with a bikini (looks hidious)",
                DescriptionOverride = "sob",
                CategoryOverride = ModAPI.FindCategory("Random Mod"),
                ThumbnailOverride = ModAPI.LoadSprite("Sprites/revampedpro.png"),
                AfterSpawn = (Instance) =>
                {
                    var skin = ModAPI.LoadTexture("Sprites/revampedpro.png");
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
                NameOverride = "Me",
                DescriptionOverride = "A male Speciman that lives in sydney",
                CategoryOverride = ModAPI.FindCategory("Random Mod"),
                ThumbnailOverride = ModAPI.LoadSprite("Sprites/me.png"),
                AfterSpawn = (Instance) =>
                {
                    var skin = ModAPI.LoadTexture("Sprites/me.png");
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
/*
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
            */

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

            ModAPI.Register(new Modification()
            {
                OriginalItem = ModAPI.FindSpawnable("Knife"),
                NameOverride = "Knife 2.0",
                DescriptionOverride = "Pro",
                CategoryOverride = ModAPI.FindCategory("Random Mod"),
                ThumbnailOverride = ModAPI.LoadSprite("Sprites/knife2.0.png"),
                AfterSpawn = (Instance) =>
                {
                    Instance.GetComponent<SpriteRenderer>().sprite = ModAPI.LoadSprite("Sprites/knife2.0.png");
                    Instance.FixColliders();
                }
            });

            // Register an explosion rod
            ModAPI.Register(new Modification()
            {
                OriginalItem = ModAPI.FindSpawnable("Rod"),
                NameOverride = "Logo",
                DescriptionOverride = "Spawn the Mind Blowning Terrible Logo of Random Mod",
                CategoryOverride = ModAPI.FindCategory("Random Mod"),
                ThumbnailOverride = ModAPI.LoadSprite("ModStuff/pixil-frame-0 (2).png"),
                AfterSpawn = (Instance) =>
                {
                    Instance.GetComponent<SpriteRenderer>().sprite = ModAPI.LoadSprite("ModStuff/pixil-frame-0 (2).png");
                    Instance.AddComponent<ExplosionThing>();
                    Instance.FixColliders();
                }
            });

            ModAPI.Register(new Modification()
            {
                OriginalItem = ModAPI.FindSpawnable("Flamethrower"),
                NameOverride = "Flame Thrower",
                DescriptionOverride = "Reskinned to be colorful and bright",
                CategoryOverride = ModAPI.FindCategory("Random Mod"),
                ThumbnailOverride = ModAPI.LoadSprite("Sprites/flamethrower.png"),
                AfterSpawn = (Instance) =>
                {
                    Instance.GetComponent<SpriteRenderer>().sprite = ModAPI.LoadSprite("Sprites/flamethrower.png");
                    Instance.FixColliders();
                }
            });

            ModAPI.Register(new Modification()
            {
                OriginalItem = ModAPI.FindSpawnable("Flamethrower"),
                NameOverride = "Flame Thrower",
                DescriptionOverride = "Reskinned to be colorful and bright",
                CategoryOverride = ModAPI.FindCategory("Random Mod"),
                ThumbnailOverride = ModAPI.LoadSprite("Sprites/flamethrower.png"),
                AfterSpawn = (Instance) =>
                {
                    Instance.GetComponent<SpriteRenderer>().sprite = ModAPI.LoadSprite("Sprites/flamethrower.png");
                    Instance.FixColliders();
                }
            });

            ModAPI.Register(new Modification()
            {
                OriginalItem = ModAPI.FindSpawnable("Handgrenade"),
                NameOverride = "Blue Grenade",
                DescriptionOverride = "I have no idea",
                CategoryOverride = ModAPI.FindCategory("Random Mod"),
                ThumbnailOverride = ModAPI.LoadSprite("Sprites/grenade.png"),
                AfterSpawn = (Instance) =>
                {
                    Instance.GetComponent<SpriteRenderer>().sprite = ModAPI.LoadSprite("Sprites/grenade.png");
                    Instance.FixColliders();
                }
            });


            ModAPI.Register(new Modification()
            {
                OriginalItem = ModAPI.FindSpawnable("Rod"),
                NameOverride = "Random Mod Fedora",
                DescriptionOverride = "WARNING: IT WILL NOT AUTOMATICALLY WELD TO HEAD YOU HAVE TO MANUALLY WELD IT TO THE HEAD WITH THE BLACK WIRE THING",
                CategoryOverride = ModAPI.FindCategory("Random Mod"),
                ThumbnailOverride = ModAPI.LoadSprite("Sprites/Random mod fedora.png"),
                AfterSpawn = (Instance) =>
                {
                    Instance.GetComponent<SpriteRenderer>().sprite = ModAPI.LoadSprite("Sprites/Random mod fedora.png");
                    Instance.FixColliders();
                }
            });

            ModAPI.Register(new Modification()
            {
                OriginalItem = ModAPI.FindSpawnable("Knife"),
                NameOverride = "A decent looking katana",
                DescriptionOverride = "im getting so good at pixel art ong",
                CategoryOverride = ModAPI.FindCategory("Random Mod"),
                ThumbnailOverride = ModAPI.LoadSprite("Sprites/Katana.png"),
                AfterSpawn = (Instance) =>
                {
                    Instance.GetComponent<SpriteRenderer>().sprite = ModAPI.LoadSprite("Sprites/Katana.png");
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
