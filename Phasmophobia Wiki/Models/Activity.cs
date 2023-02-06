using System.ComponentModel;

namespace Phasmophobia_Wiki.Models;

/// <summary>
/// Evidence a ghost will provide that assists in determining its type.
/// </summary>
[Flags]
public enum Activity
{
    [Description("D.O.T.S Projector")]
    Dots = 1 << 0,
    
    [Description("EMF Level 5")]
    Emf = 1 << 1,
    
    [Description("Fingerprints")]
    Fingerprints = 1 << 2,
    
    [Description("Freezing Temperatures")]
    FreezingTemperatures = 1 << 3,
    
    [Description("Ghost Orbs")]
    GhostOrbs = 1 << 4,
    
    [Description("Ghost Writing")]
    GhostWriting = 1 << 5,
    
    [Description("Spirit Box")]
    SpiritBox = 1 << 6
}
