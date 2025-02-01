﻿using System;
using System.Collections.Generic;

namespace Restaurant.Models;

public partial class MasterSocialMedium : BaseEntity
{
    public int MasterSocialMediumId { get; set; }

    public string MasterSocialMediaImageUrl { get; set; } = null!;

    public string MasterSocialMediaUrl { get; set; } = null!;
}
