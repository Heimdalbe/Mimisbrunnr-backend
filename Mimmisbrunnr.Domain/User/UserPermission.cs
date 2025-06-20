using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mimmisbrunnr.Domain.User
{
    internal enum UserPermission
    {
        createEvent,
        deleteEvent,
        updateEvent,

        favoriteEvent,
        enroleEvent,

        createAlbum,
        deleteAlbum,
        updateAlbum,
        hideAlbum,

        createSponsor,
        deleteSponsor,
        updateSponsor,

        createUser,
        deleteUser,
        updateUser,

        createRole,
        deleteRole,
        updateRole,

        addPermission,
        removePermission,

        canVote,
        updateVoteEligibility,
        updateVoteWeight, //aantal stemmen per persoon
        resetVoteWeight,

        createElection,
        deleteElection,
        updateElection,
       
        createRound,
        deleteRound,
        updateRound,
    }
}
