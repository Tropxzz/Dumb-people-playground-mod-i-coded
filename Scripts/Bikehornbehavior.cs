public class BikeHornAttachmentBehaviour : FirearmAttachmentBehaviour
{
    public AudioClip HornNoise; // The audio clip that will play on fire

    public override void OnConnect() { }

    public override void OnDisconnect() { }

    public override void OnFire()
    {
        // on fire, get the physical behaviour and run the PlayClipOnce method
        // note that you don't need to have the 'clip:' parts in the method's parameters, it makes it easier to tell what the parameters you're setting.
        Phys.PlayClipOnce(clip: HornNoise, volume: 1.5f);
    }

    public override void OnHit(BallisticsEmitter.CallbackParams args) { }
}