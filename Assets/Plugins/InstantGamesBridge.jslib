mergeInto(LibraryManager.library, {

    InstantGamesBridgeGetPlatformId: function() {
        var platformId = window.getPlatformId()
        var bufferSize = lengthBytesUTF8(platformId) + 1
        var buffer = _malloc(bufferSize)
        stringToUTF8(platformId, buffer, bufferSize)
        return buffer
    },

    InstantGamesBridgeGetPlatformLanguage: function() {
        var platformLanguage = window.getPlatformLanguage()
        var bufferSize = lengthBytesUTF8(platformLanguage) + 1
        var buffer = _malloc(bufferSize)
        stringToUTF8(platformLanguage, buffer, bufferSize)
        return buffer
    },

    InstantGamesBridgeGetPlatformPayload: function() {
        var platformPayload = window.getPlatformPayload()
        var bufferSize = lengthBytesUTF8(platformPayload) + 1
        var buffer = _malloc(bufferSize)
        stringToUTF8(platformPayload, buffer, bufferSize)
        return buffer
    },
    
    InstantGamesBridgeGetPlatformTld: function() {
        var platformTld = window.getPlatformTld()
        var bufferSize = lengthBytesUTF8(platformTld) + 1
        var buffer = _malloc(bufferSize)
        stringToUTF8(platformTld, buffer, bufferSize)
        return buffer
    },
    
    InstantGamesBridgeSendMessageToPlatform: function(message) {
        window.sendMessageToPlatform(UTF8ToString(message))
    },


    InstantGamesBridgeGetDeviceType: function() {
        var deviceType = window.getDeviceType()
        var bufferSize = lengthBytesUTF8(deviceType) + 1
        var buffer = _malloc(bufferSize)
        stringToUTF8(deviceType, buffer, bufferSize)
        return buffer
    },


    InstantGamesBridgeIsPlayerAuthorizationSupported: function() {
        var isPlayerAuthorizationSupported = window.getIsPlayerAuthorizationSupported()
        var bufferSize = lengthBytesUTF8(isPlayerAuthorizationSupported) + 1
        var buffer = _malloc(bufferSize)
        stringToUTF8(isPlayerAuthorizationSupported, buffer, bufferSize)
        return buffer
    },

    InstantGamesBridgeIsPlayerAuthorized: function() {
        var isPlayerAuthorized = window.getIsPlayerAuthorized()
        var bufferSize = lengthBytesUTF8(isPlayerAuthorized) + 1
        var buffer = _malloc(bufferSize)
        stringToUTF8(isPlayerAuthorized, buffer, bufferSize)
        return buffer
    },

    InstantGamesBridgePlayerId: function() {
        var playerId = window.getPlayerId()
        var bufferSize = lengthBytesUTF8(playerId) + 1
        var buffer = _malloc(bufferSize)
        stringToUTF8(playerId, buffer, bufferSize)
        return buffer
    },

    InstantGamesBridgePlayerName: function() {
        var playerName = window.getPlayerName()
        var bufferSize = lengthBytesUTF8(playerName) + 1
        var buffer = _malloc(bufferSize)
        stringToUTF8(playerName, buffer, bufferSize)
        return buffer
    },

    InstantGamesBridgePlayerPhotos: function() {
        var playerPhotos = window.getPlayerPhotos()
        var bufferSize = lengthBytesUTF8(playerPhotos) + 1
        var buffer = _malloc(bufferSize)
        stringToUTF8(playerPhotos, buffer, bufferSize)
        return buffer
    },

    InstantGamesBridgeAuthorizePlayer: function(options) {
        window.authorizePlayer(UTF8ToString(options))
    },


    InstantGamesBridgeGetVisibilityState: function() {
        var visibilityState = window.getVisibilityState()
        var bufferSize = lengthBytesUTF8(visibilityState) + 1
        var buffer = _malloc(bufferSize)
        stringToUTF8(visibilityState, buffer, bufferSize)
        return buffer
    },


    InstantGamesBridgeGetStorageDefaultType: function() {
        var storageType = window.getStorageDefaultType()
        var bufferSize = lengthBytesUTF8(storageType) + 1
        var buffer = _malloc(bufferSize)
        stringToUTF8(storageType, buffer, bufferSize)
        return buffer
    },

    InstantGamesBridgeIsStorageSupported: function(storageType) {
        var isStorageSupported = window.getIsStorageSupported(UTF8ToString(storageType))
        var bufferSize = lengthBytesUTF8(isStorageSupported) + 1
        var buffer = _malloc(bufferSize)
        stringToUTF8(isStorageSupported, buffer, bufferSize)
        return buffer
    },

    InstantGamesBridgeIsStorageAvailable: function(storageType) {
        var isStorageAvailable = window.getIsStorageAvailable(UTF8ToString(storageType))
        var bufferSize = lengthBytesUTF8(isStorageAvailable) + 1
        var buffer = _malloc(bufferSize)
        stringToUTF8(isStorageAvailable, buffer, bufferSize)
        return buffer
    },

    InstantGamesBridgeGetStorageData: function(key, storageType) {
        window.getStorageData(UTF8ToString(key), UTF8ToString(storageType))
    },

    InstantGamesBridgeSetStorageData: function(key, value, storageType) {
        window.setStorageData(UTF8ToString(key), UTF8ToString(value), UTF8ToString(storageType))
    },

    InstantGamesBridgeDeleteStorageData: function(key, storageType) {
        window.deleteStorageData(UTF8ToString(key), UTF8ToString(storageType))
    },


    InstantGamesBridgeGetInterstitialState: function() {
        var interstitialState = window.getInterstitialState()
        var bufferSize = lengthBytesUTF8(interstitialState) + 1
        var buffer = _malloc(bufferSize)
        stringToUTF8(interstitialState, buffer, bufferSize)
        return buffer
    },

    InstantGamesBridgeIsBannerSupported: function() {
        var isBannerSupported = window.getIsBannerSupported()
        var bufferSize = lengthBytesUTF8(isBannerSupported) + 1
        var buffer = _malloc(bufferSize)
        stringToUTF8(isBannerSupported, buffer, bufferSize)
        return buffer
    },

    InstantGamesBridgeMinimumDelayBetweenInterstitial: function() {
        var minimumDelayBetweenInterstitial = window.getMinimumDelayBetweenInterstitial()
        var bufferSize = lengthBytesUTF8(minimumDelayBetweenInterstitial) + 1
        var buffer = _malloc(bufferSize)
        stringToUTF8(minimumDelayBetweenInterstitial, buffer, bufferSize)
        return buffer
    },

    InstantGamesBridgeSetMinimumDelayBetweenInterstitial: function(options) {
        window.setMinimumDelayBetweenInterstitial(UTF8ToString(options))
    },
    
    InstantGamesBridgeShowBanner: function(options) {
        window.showBanner(UTF8ToString(options))
    },
        
    InstantGamesBridgeHideBanner: function() {
        window.hideBanner()
    },

    InstantGamesBridgeShowInterstitial: function(options) {
        window.showInterstitial(UTF8ToString(options))
    },

    InstantGamesBridgeShowRewarded: function() {
        window.showRewarded()
    },


    InstantGamesBridgeIsShareSupported: function() {
        var isShareSupported = window.getIsShareSupported()
        var bufferSize = lengthBytesUTF8(isShareSupported) + 1
        var buffer = _malloc(bufferSize)
        stringToUTF8(isShareSupported, buffer, bufferSize)
        return buffer
    },

    InstantGamesBridgeIsInviteFriendsSupported: function() {
        var isInviteFriendsSupported = window.getIsInviteFriendsSupported()
        var bufferSize = lengthBytesUTF8(isInviteFriendsSupported) + 1
        var buffer = _malloc(bufferSize)
        stringToUTF8(isInviteFriendsSupported, buffer, bufferSize)
        return buffer
    },

    InstantGamesBridgeIsJoinCommunitySupported: function() {
        var isJoinCommunitySupported = window.getIsJoinCommunitySupported()
        var bufferSize = lengthBytesUTF8(isJoinCommunitySupported) + 1
        var buffer = _malloc(bufferSize)
        stringToUTF8(isJoinCommunitySupported, buffer, bufferSize)
        return buffer
    },

    InstantGamesBridgeIsCreatePostSupported: function() {
        var isCreatePostSupported = window.getIsCreatePostSupported()
        var bufferSize = lengthBytesUTF8(isCreatePostSupported) + 1
        var buffer = _malloc(bufferSize)
        stringToUTF8(isCreatePostSupported, buffer, bufferSize)
        return buffer
    },

    InstantGamesBridgeIsAddToHomeScreenSupported: function() {
        var isAddToHomeScreenSupported = window.getIsAddToHomeScreenSupported()
        var bufferSize = lengthBytesUTF8(isAddToHomeScreenSupported) + 1
        var buffer = _malloc(bufferSize)
        stringToUTF8(isAddToHomeScreenSupported, buffer, bufferSize)
        return buffer
    },

    InstantGamesBridgeIsAddToFavoritesSupported: function() {
        var isAddToFavoritesSupported = window.getIsAddToFavoritesSupported()
        var bufferSize = lengthBytesUTF8(isAddToFavoritesSupported) + 1
        var buffer = _malloc(bufferSize)
        stringToUTF8(isAddToFavoritesSupported, buffer, bufferSize)
        return buffer
    },

    InstantGamesBridgeIsRateSupported: function() {
        var isRateSupported = window.getIsRateSupported()
        var bufferSize = lengthBytesUTF8(isRateSupported) + 1
        var buffer = _malloc(bufferSize)
        stringToUTF8(isRateSupported, buffer, bufferSize)
        return buffer
    },

    InstantGamesBridgeIsExternalLinksAllowed: function() {
        var isExternalLinksAllowed = window.getIsExternalLinksAllowed()
        var bufferSize = lengthBytesUTF8(isExternalLinksAllowed) + 1
        var buffer = _malloc(bufferSize)
        stringToUTF8(isExternalLinksAllowed, buffer, bufferSize)
        return buffer
    },

    InstantGamesBridgeShare: function(options) {
        window.share(UTF8ToString(options))
    },

    InstantGamesBridgeInviteFriends: function() {
        window.inviteFriends()
    },

    InstantGamesBridgeJoinCommunity: function(options) {
        window.joinCommunity(UTF8ToString(options))
    },

    InstantGamesBridgeCreatePost: function(options) {
        window.createPost(UTF8ToString(options))
    },

    InstantGamesBridgeAddToHomeScreen: function() {
        window.addToHomeScreen()
    },

    InstantGamesBridgeAddToFavorites: function() {
        window.addToFavorites()
    },

    InstantGamesBridgeRate: function() {
        window.rate()
    },


    InstantGamesBridgeIsLeaderboardSupported: function() {
        var isLeaderboardSupported = window.getIsLeaderboardSupported()
        var bufferSize = lengthBytesUTF8(isLeaderboardSupported) + 1
        var buffer = _malloc(bufferSize)
        stringToUTF8(isLeaderboardSupported, buffer, bufferSize)
        return buffer
    },

    InstantGamesBridgeIsLeaderboardNativePopupSupported: function() {
        var isLeaderboardNativePopupSupported = window.getIsLeaderboardNativePopupSupported()
        var bufferSize = lengthBytesUTF8(isLeaderboardNativePopupSupported) + 1
        var buffer = _malloc(bufferSize)
        stringToUTF8(isLeaderboardNativePopupSupported, buffer, bufferSize)
        return buffer
    },

    InstantGamesBridgeIsLeaderboardMultipleBoardsSupported: function() {
        var isLeaderboardMultipleBoardsSupported = window.getIsLeaderboardMultipleBoardsSupported()
        var bufferSize = lengthBytesUTF8(isLeaderboardMultipleBoardsSupported) + 1
        var buffer = _malloc(bufferSize)
        stringToUTF8(isLeaderboardMultipleBoardsSupported, buffer, bufferSize)
        return buffer
    },

    InstantGamesBridgeIsLeaderboardSetScoreSupported: function() {
        var isLeaderboardSetScoreSupported = window.getIsLeaderboardSetScoreSupported()
        var bufferSize = lengthBytesUTF8(isLeaderboardSetScoreSupported) + 1
        var buffer = _malloc(bufferSize)
        stringToUTF8(isLeaderboardSetScoreSupported, buffer, bufferSize)
        return buffer
    },

    InstantGamesBridgeIsLeaderboardGetScoreSupported: function() {
        var isLeaderboardGetScoreSupported = window.getIsLeaderboardGetScoreSupported()
        var bufferSize = lengthBytesUTF8(isLeaderboardGetScoreSupported) + 1
        var buffer = _malloc(bufferSize)
        stringToUTF8(isLeaderboardGetScoreSupported, buffer, bufferSize)
        return buffer
    },

    InstantGamesBridgeIsLeaderboardGetEntriesSupported: function() {
        var isLeaderboardGetEntriesSupported = window.getIsLeaderboardGetEntriesSupported()
        var bufferSize = lengthBytesUTF8(isLeaderboardGetEntriesSupported) + 1
        var buffer = _malloc(bufferSize)
        stringToUTF8(isLeaderboardGetEntriesSupported, buffer, bufferSize)
        return buffer
    },

    InstantGamesBridgeLeaderboardSetScore: function(options) {
        window.leaderboardSetScore(UTF8ToString(options))
    },

    InstantGamesBridgeLeaderboardGetScore: function(options) {
        window.leaderboardGetScore(UTF8ToString(options))
    },

    InstantGamesBridgeLeaderboardGetEntries: function(options) {
        window.leaderboardGetEntries(UTF8ToString(options))
    },

    InstantGamesBridgeLeaderboardShowNativePopup: function(options) {
        window.leaderboardShowNativePopup(UTF8ToString(options))
    },

    InstantGamesBridgeIsPaymentsSupported: function() {
        var isPaymentsSupported = window.getIsPaymentsSupported()
        var bufferSize = lengthBytesUTF8(isPaymentsSupported) + 1
        var buffer = _malloc(bufferSize)
        stringToUTF8(isPaymentsSupported, buffer, bufferSize)
        return buffer
    },

    InstantGamesBridgePaymentsPurchase: function(id) {
        window.paymentsPurchase(UTF8ToString(id))
    },

    InstantGamesBridgePaymentsConsumePurchase: function(token) {
        window.paymentsConsumePurchase(UTF8ToString(token))
    },
    
    InstantGamesBridgePaymentsGetPurchases: function() {
        window.paymentsGetPurchases()
    },
        
    InstantGamesBridgePaymentsGetCatalog: function() {
        window.paymentsGetCatalog()
    }

});