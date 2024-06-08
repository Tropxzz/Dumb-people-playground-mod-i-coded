using System;
using UnityEngine;

namespace Mod
{
    public class Mod
    {
        public static void Main()
        {
            // Create a new category for the mod
            CategoryBuilder.Create("Random Mod", "So pro for some reason", ModAPI.LoadSprite("ModStuff/pixil-frame-0 (2).png"));

            // Register a new modification for the Knife
            ModAPI.Register(new Modification()
            {
                OriginalItem = ModAPI.FindSpawnable("Knife"), // item to derive from
                NameOverride = "Knife I terribly made", // new item name with a suffix to assure it is globally unique
                DescriptionOverride = "Knife with different Texture.", // new item description
                CategoryOverride = ModAPI.FindCategory("Random Mod"), // new item category
                ThumbnailOverride = ModAPI.LoadSprite("Thumbnails/Knife Thumbnail.jpg"), // new item thumbnail (relative path)
                AfterSpawn = (Instance) =>
                {
                    Instance.GetComponent<SpriteRenderer>().sprite = ModAPI.LoadSprite("Sprites/Knife Sprite.png");
                    Instance.FixColliders();
                }
            });

            // Register another modification for the Knife
            ModAPI.Register(new Modification()
            {
                OriginalItem = ModAPI.FindSpawnable("Knife"), // item to derive from
                NameOverride = "Normal Sized Foosh", // new item name with a suffix to assure it is globally unique
                DescriptionOverride = "Damn we're playing with humans that are smaller, craaaaaaaaaaaaaaaaazy.", // new item description
                CategoryOverride = ModAPI.FindCategory("Random Mod"), // new item category
                ThumbnailOverride = ModAPI.LoadSprite("Thumbnails/electric-floppy-fish-toy-moving-cat-kicker-fish-toy-11-realistic-flopping-fish-dog-toy.png"), // new item thumbnail (relative path)
                AfterSpawn = (Instance) =>
                {
                    Instance.GetComponent<SpriteRenderer>().sprite = ModAPI.LoadSprite("Sprites/Knife.png");
                    Instance.FixColliders();
                }
            });

            // Register a modification for the Scope Attachment
            ModAPI.Register(new Modification()
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
                    attachment.AttachmentOffset = Vector2.zero; // the offset from the attachment point (generally only used if you want the sprite to be within the gun and stuff)

                    // setting the new audio clip
                    attachment.HornNoise = ModAPI.LoadSound("Sounds/bicycle-horn-7126.mp3");
                }
            });

            // Register a modification for the General Purpose Bomb
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



            

            // Register a modification for the Human
            ModAPI.Register(new Modification()
            {
                OriginalItem = ModAPI.FindSpawnable("Human"), // item to derive from
                NameOverride = "Isaiah", // new item name with a suffix to assure it is globally unique
                DescriptionOverride = "A Male Human Specimen from Newcastle", // new item description
                CategoryOverride = ModAPI.FindCategory("Random Mod"), // new item category
                ThumbnailOverride = ModAPI.LoadSprite("Thumbnails/Isaiah.png"), // new item thumbnail (relative path)
                AfterSpawn = (Instance) =>
                {
                    // load textures for each layer (see Human textures folder in this repository)
                    var skin = ModAPI.LoadTexture("Thumbnails/Isaiah.png");
                    var flesh = ModAPI.LoadTexture("Human Stuff/flesh layer.png");
                    var bone = ModAPI.LoadTexture("Human Stuff/bone layer.png");

                    // get person
                    var person = Instance.GetComponent<PersonBehaviour>();

                    // use the helper function to set each texture
                    // parameters are as follows: 
                    //  skin texture, flesh texture, bone texture, sprite scale
                    // you can pass "null" to fall back to the original texture
                    person.SetBodyTextures(skin, flesh, bone, 1);

                    // change procedural damage colours if they interfere with your texture (rgb 0-255)
                    person.SetBruiseColor(86, 62, 130); // main bruise colour. purple-ish by default
                    person.SetSecondBruiseColor(154, 0, 7); // second bruise colour. red by default
                    person.SetThirdBruiseColor(207, 206, 120); // third bruise colour. light yellow by default
                    person.SetRottenColour(202, 199, 104); // rotten/zombie colour. light yellow/green by default
                    person.SetBloodColour(108, 0, 4); // blood colour. dark red by default. note that this does not change decal nor particle effect colours. it only affects the procedural blood color which may or may not be rendered
                }
            });

            ModAPI.Register(new Modification()
            {
                OriginalItem = ModAPI.FindSpawnable("Human"), // item to derive from
                NameOverride = "Rock with a binkini", // new item name with a suffix to assure it is globally unique
                DescriptionOverride = "sob", // new item description
                CategoryOverride = ModAPI.FindCategory("Random Mod"), // new item category
                ThumbnailOverride = ModAPI.LoadSprite("Sprites/pro.png"), // new item thumbnail (relative path)
                AfterSpawn = (Instance) =>
                {
                    // load textures for each layer (see Human textures folder in this repository)
                    var skin = ModAPI.LoadTexture("Sprites/pro.png");
                    var flesh = ModAPI.LoadTexture("Human Stuff/flesh layer.png");
                    var bone = ModAPI.LoadTexture("Human Stuff/bone layer.png");

                    // get person
                    var person = Instance.GetComponent<PersonBehaviour>();

                    // use the helper function to set each texture
                    // parameters are as follows: 
                    //  skin texture, flesh texture, bone texture, sprite scale
                    // you can pass "null" to fall back to the original texture
                    person.SetBodyTextures(skin, flesh, bone, 1);

                    // change procedural damage colours if they interfere with your texture (rgb 0-255)
                    person.SetBruiseColor(86, 62, 130); // main bruise colour. purple-ish by default
                    person.SetSecondBruiseColor(154, 0, 7); // second bruise colour. red by default
                    person.SetThirdBruiseColor(207, 206, 120); // third bruise colour. light yellow by default
                    person.SetRottenColour(202, 199, 104); // rotten/zombie colour. light yellow/green by default
                    person.SetBloodColour(108, 0, 4); // blood colour. dark red by default. note that this does not change decal nor particle effect colours. it only affects the procedural blood color which may or may not be rendered
                }
            });

            // Register another modification for the Human
            ModAPI.Register(new Modification()
            {
                OriginalItem = ModAPI.FindSpawnable("Human"), // item to derive from
                NameOverride = "Elijah", // new item name with a suffix to assure it is globally unique
                DescriptionOverride = "A Male Human Specimen from Newcastle", // new item description
                CategoryOverride = ModAPI.FindCategory("Random Mod"), // new item category
                ThumbnailOverride = ModAPI.LoadSprite("Sprites/Untitled-removebg-preview (1).png"), // new item thumbnail (relative path)
                AfterSpawn = (Instance) =>
                {
                    // load textures for each layer (see Human textures folder in this repository)
                    var skin = ModAPI.LoadTexture("Sprites/Untitled-removebg-preview (1).png");
                    var flesh = ModAPI.LoadTexture("Human Stuff/flesh layer.png");
                    var bone = ModAPI.LoadTexture("Human Stuff/bone layer.png");

                    // get person
                    var person = Instance.GetComponent<PersonBehaviour>();

                    // use the helper function to set each texture
                    // parameters are as follows: 
                    //  skin texture, flesh texture, bone texture, sprite scale
                    // you can pass "null" to fall back to the original texture
                    person.SetBodyTextures(skin, flesh, bone, 1);

                    // change procedural damage colours if they interfere with your texture (rgb 0-255)
                    person.SetBruiseColor(86, 62, 130); // main bruise colour. purple-ish by default
                    person.SetSecondBruiseColor(154, 0, 7); // second bruise colour. red by default
                    person.SetThirdBruiseColor(207, 206, 120); // third bruise colour. light yellow by default
                    person.SetRottenColour(202, 199, 104); // rotten/zombie colour. light yellow/green by default
                    person.SetBloodColour(108, 0, 4); // blood colour. dark red by default. note that this does not change decal nor particle effect colours. it only affects the procedural blood color which may or may not be rendered
                }
            });

            // Register a modification for the Pistol
            ModAPI.Register(new Modification()
            {
                OriginalItem = ModAPI.FindSpawnable("Pistol"), // item to derive from
                NameOverride = "Gun Agent 47 uses", // new item name with a suffix to assure it is globally unique
                DescriptionOverride = "pew pew", // new item description
                CategoryOverride = ModAPI.FindCategory("Random Mod"), // new item category
                ThumbnailOverride = ModAPI.LoadSprite("Sprites/@freeroboxgenerator is einstein.png"), // new item thumbnail (relative path)
                AfterSpawn = (Instance) => // all code in the AfterSpawn delegate will be executed when the item is spawned
                {
                    // setting the sprite
                    Instance.GetComponent<SpriteRenderer>().sprite = ModAPI.LoadSprite("Sprites/@freeroboxgenerator is einstein.png");

                    // getting the FirearmBehaviour for later manipulation
                    var firearm = Instance.GetComponent<FirearmBehaviour>();

                    // creating a custom cartridge for the gun
                    Cartridge customCartridge = ModAPI.FindCartridge("9mm"); // load a copy of the 9mm cartridge
                    customCartridge.name = "7.63×25mm Mauser"; // set a name
                    customCartridge.Damage *= 1f; // change the damage however you like
                    customCartridge.StartSpeed *= 5f; // change the bullet velocity
                    customCartridge.PenetrationRandomAngleMultiplier *= 0.5f; // change the accuracy when the bullet travels through an object
                    customCartridge.Recoil *= 2f; // change the recoil
                    customCartridge.ImpactForce *= 0.7f; // change how much the bullet pushes the target

                    // set the cartridge to the FirearmBehaviour
                    firearm.Cartridge = customCartridge;

                    // set the new gun sounds. this is an array of AudioClips that is picked from at random when shot
                    firearm.ShotSounds = new AudioClip[]
                    {
                    };

                    // set the collision box to the new sprite shape
                    // this is the easiest way to fix your collision shape, but it also the slowest.
                    Instance.FixColliders();
                }
            });
        }
    }

    public class BikeHornAttachmentBehaviour : FirearmAttachmentBehaviour
    {
        public AudioClip HornNoise; // The audio clip that will play on fire

        // method that is called on connection
        public override void OnConnect() { }

        // method that is called on disconnection
        public override void OnDisconnect() { }

        // method that is called when the gun is fired
        public override void OnFire()
        {
            // on fire, get the physical behaviour and run the PlayClipOnce method
            PhysicalBehaviour.PlayClipOnce(clip: HornNoise, volume: 2.5f);
        }

        // method that is called when a bullet hits an object
        public override void OnHit(BallisticsEmitter.CallbackParams args)
        {
            // args contains the position of the bullet, direction of the bullet, object that was hit, and the surface normal the bullet hit.
        }
    }
}
