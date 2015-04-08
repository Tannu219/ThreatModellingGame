namespace ThreatModellingGame.Core
{
    /// <summary>
    /// STRIDE categories.
    /// http://en.wikipedia.org/wiki/STRIDE_(security)
    /// </summary>
    public enum Suit
    {
        /// <summary>
        /// Impersonating something or someone else.
        /// </summary>
        Spoofing,
        /// <summary>
        /// Modifying data or code.
        /// </summary>
        Tampering,
        /// <summary>
        /// Claiming not to have performed an action.
        /// </summary>
        Repudiation,
        /// <summary>
        /// Exposing information to someone not authorized to see it.
        /// </summary>
        InformationDisclosure,
        /// <summary>
        /// Denying or degrading service to users.
        /// </summary>
        DenialOfService,
        /// <summary>
        /// Gain capabilities without proper authorization.
        /// </summary>
        ElevationOfPrivilege
    }
}