using GTA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GTACommon.Extensions
{
    public static class PlayerExtensions
    {
        public static bool IsUsingCustomModel(this Player player)
        {
            if (!player.Character.Model.IsHumanPed)
                return false;

            var _pedHash = (PedHash)player.Character.Model.Hash;
            return _pedHash != PedHash.Franklin &&
                _pedHash != PedHash.Franklin02 &&
                _pedHash != PedHash.Michael &&
                _pedHash != PedHash.Trevor;
        }
    }
}
