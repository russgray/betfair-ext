﻿using System;
using BetfairExt.BFExchange;

namespace BetfairExt.Interfaces
{
    public interface IBFExchangeServiceClient
    {
        IAsyncResult BegincancelBets(CancelBetsReq request, AsyncCallback callback, object asyncState);
        IAsyncResult BegincancelBetsByMarket(CancelBetsByMarketReq request, AsyncCallback callback, object asyncState);
        IAsyncResult BegingetAccountFunds(GetAccountFundsReq request, AsyncCallback callback, object asyncState);
        IAsyncResult BegingetAccountStatement(GetAccountStatementReq req, AsyncCallback callback, object asyncState);
        IAsyncResult BegingetAllMarkets(GetAllMarketsReq request, AsyncCallback callback, object asyncState);
        IAsyncResult BegingetBet(GetBetReq request, AsyncCallback callback, object asyncState);
        IAsyncResult BegingetBetHistory(GetBetHistoryReq request, AsyncCallback callback, object asyncState);
        IAsyncResult BegingetBetLite(GetBetLiteReq request, AsyncCallback callback, object asyncState);
        IAsyncResult BegingetBetMatchesLite(GetBetMatchesLiteReq request, AsyncCallback callback, object asyncState);
        IAsyncResult BegingetCompleteMarketPricesCompressed(GetCompleteMarketPricesCompressedReq request, AsyncCallback callback, object asyncState);
        IAsyncResult BegingetCoupon(GetCouponReq request, AsyncCallback callback, object asyncState);
        IAsyncResult BegingetCurrentBets(GetCurrentBetsReq request, AsyncCallback callback, object asyncState);
        IAsyncResult BegingetCurrentBetsLite(GetCurrentBetsLiteReq request, AsyncCallback callback, object asyncState);
        IAsyncResult BegingetDetailAvailableMktDepth(GetDetailedAvailableMktDepthReq request, AsyncCallback callback, object asyncState);
        IAsyncResult BegingetInPlayMarkets(GetInPlayMarketsReq request, AsyncCallback callback, object asyncState);
        IAsyncResult BegingetMarket(GetMarketReq request, AsyncCallback callback, object asyncState);
        IAsyncResult BegingetMarketInfo(GetMarketInfoReq request, AsyncCallback callback, object asyncState);
        IAsyncResult BegingetMarketPrices(GetMarketPricesReq request, AsyncCallback callback, object asyncState);
        IAsyncResult BegingetMarketPricesCompressed(GetMarketPricesCompressedReq request, AsyncCallback callback, object asyncState);
        IAsyncResult BegingetMarketProfitAndLoss(GetMarketProfitAndLossReq request, AsyncCallback callback, object asyncState);
        IAsyncResult BegingetMarketTradedVolume(GetMarketTradedVolumeReq request, AsyncCallback callback, object asyncState);
        IAsyncResult BegingetMarketTradedVolumeCompressed(GetMarketTradedVolumeCompressedReq request, AsyncCallback callback, object asyncState);
        IAsyncResult BegingetMUBets(GetMUBetsReq request, AsyncCallback callback, object asyncState);
        IAsyncResult BegingetMUBetsLite(GetMUBetsLiteReq request, AsyncCallback callback, object asyncState);
        IAsyncResult BegingetPrivateMarkets(GetPrivateMarketsReq request, AsyncCallback callback, object asyncState);
        IAsyncResult BegingetSilks(GetSilksReq request, AsyncCallback callback, object asyncState);
        IAsyncResult BegingetSilksV2(GetSilksV2Req request, AsyncCallback callback, object asyncState);
        IAsyncResult Beginheartbeat(HeartbeatReq request, AsyncCallback callback, object asyncState);
        IAsyncResult BeginplaceBets(PlaceBetsReq request, AsyncCallback callback, object asyncState);
        IAsyncResult BeginupdateBets(UpdateBetsReq request, AsyncCallback callback, object asyncState);
        CancelBetsResp cancelBets(CancelBetsReq request);
        void cancelBetsAsync(CancelBetsReq request);
        void cancelBetsAsync(CancelBetsReq request, object userState);
        CancelBetsByMarketResp cancelBetsByMarket(CancelBetsByMarketReq request);
        void cancelBetsByMarketAsync(CancelBetsByMarketReq request);
        void cancelBetsByMarketAsync(CancelBetsByMarketReq request, object userState);
        event EventHandler<cancelBetsByMarketCompletedEventArgs> cancelBetsByMarketCompleted;
        event EventHandler<cancelBetsCompletedEventArgs> cancelBetsCompleted;
        CancelBetsResp EndcancelBets(IAsyncResult result);
        CancelBetsByMarketResp EndcancelBetsByMarket(IAsyncResult result);
        GetAccountFundsResp EndgetAccountFunds(IAsyncResult result);
        GetAccountStatementResp EndgetAccountStatement(IAsyncResult result);
        GetAllMarketsResp EndgetAllMarkets(IAsyncResult result);
        GetBetResp EndgetBet(IAsyncResult result);
        GetBetHistoryResp EndgetBetHistory(IAsyncResult result);
        GetBetLiteResp EndgetBetLite(IAsyncResult result);
        GetBetMatchesLiteResp EndgetBetMatchesLite(IAsyncResult result);
        GetCompleteMarketPricesCompressedResp EndgetCompleteMarketPricesCompressed(IAsyncResult result);
        GetCouponResp EndgetCoupon(IAsyncResult result);
        GetCurrentBetsResp EndgetCurrentBets(IAsyncResult result);
        GetCurrentBetsLiteResp EndgetCurrentBetsLite(IAsyncResult result);
        GetDetailedAvailableMktDepthResp EndgetDetailAvailableMktDepth(IAsyncResult result);
        GetInPlayMarketsResp EndgetInPlayMarkets(IAsyncResult result);
        GetMarketResp EndgetMarket(IAsyncResult result);
        GetMarketInfoResp EndgetMarketInfo(IAsyncResult result);
        GetMarketPricesResp EndgetMarketPrices(IAsyncResult result);
        GetMarketPricesCompressedResp EndgetMarketPricesCompressed(IAsyncResult result);
        GetMarketProfitAndLossResp EndgetMarketProfitAndLoss(IAsyncResult result);
        GetMarketTradedVolumeResp EndgetMarketTradedVolume(IAsyncResult result);
        GetMarketTradedVolumeCompressedResp EndgetMarketTradedVolumeCompressed(IAsyncResult result);
        GetMUBetsResp EndgetMUBets(IAsyncResult result);
        GetMUBetsLiteResp EndgetMUBetsLite(IAsyncResult result);
        GetPrivateMarketsResp EndgetPrivateMarkets(IAsyncResult result);
        GetSilksResp EndgetSilks(IAsyncResult result);
        GetSilksV2Resp EndgetSilksV2(IAsyncResult result);
        HeartbeatResp Endheartbeat(IAsyncResult result);
        PlaceBetsResp EndplaceBets(IAsyncResult result);
        UpdateBetsResp EndupdateBets(IAsyncResult result);
        GetAccountFundsResp getAccountFunds(GetAccountFundsReq request);
        void getAccountFundsAsync(GetAccountFundsReq request);
        void getAccountFundsAsync(GetAccountFundsReq request, object userState);
        event EventHandler<getAccountFundsCompletedEventArgs> getAccountFundsCompleted;
        GetAccountStatementResp getAccountStatement(GetAccountStatementReq req);
        void getAccountStatementAsync(GetAccountStatementReq req);
        void getAccountStatementAsync(GetAccountStatementReq req, object userState);
        event EventHandler<getAccountStatementCompletedEventArgs> getAccountStatementCompleted;
        GetAllMarketsResp getAllMarkets(GetAllMarketsReq request);
        void getAllMarketsAsync(GetAllMarketsReq request);
        void getAllMarketsAsync(GetAllMarketsReq request, object userState);
        event EventHandler<getAllMarketsCompletedEventArgs> getAllMarketsCompleted;
        GetBetResp getBet(GetBetReq request);
        void getBetAsync(GetBetReq request);
        void getBetAsync(GetBetReq request, object userState);
        event EventHandler<getBetCompletedEventArgs> getBetCompleted;
        GetBetHistoryResp getBetHistory(GetBetHistoryReq request);
        void getBetHistoryAsync(GetBetHistoryReq request);
        void getBetHistoryAsync(GetBetHistoryReq request, object userState);
        event EventHandler<getBetHistoryCompletedEventArgs> getBetHistoryCompleted;
        GetBetLiteResp getBetLite(GetBetLiteReq request);
        void getBetLiteAsync(GetBetLiteReq request);
        void getBetLiteAsync(GetBetLiteReq request, object userState);
        event EventHandler<getBetLiteCompletedEventArgs> getBetLiteCompleted;
        GetBetMatchesLiteResp getBetMatchesLite(GetBetMatchesLiteReq request);
        void getBetMatchesLiteAsync(GetBetMatchesLiteReq request);
        void getBetMatchesLiteAsync(GetBetMatchesLiteReq request, object userState);
        event EventHandler<getBetMatchesLiteCompletedEventArgs> getBetMatchesLiteCompleted;
        GetCompleteMarketPricesCompressedResp getCompleteMarketPricesCompressed(GetCompleteMarketPricesCompressedReq request);
        void getCompleteMarketPricesCompressedAsync(GetCompleteMarketPricesCompressedReq request);
        void getCompleteMarketPricesCompressedAsync(GetCompleteMarketPricesCompressedReq request, object userState);
        event EventHandler<getCompleteMarketPricesCompressedCompletedEventArgs> getCompleteMarketPricesCompressedCompleted;
        GetCouponResp getCoupon(GetCouponReq request);
        void getCouponAsync(GetCouponReq request);
        void getCouponAsync(GetCouponReq request, object userState);
        event EventHandler<getCouponCompletedEventArgs> getCouponCompleted;
        GetCurrentBetsResp getCurrentBets(GetCurrentBetsReq request);
        void getCurrentBetsAsync(GetCurrentBetsReq request);
        void getCurrentBetsAsync(GetCurrentBetsReq request, object userState);
        event EventHandler<getCurrentBetsCompletedEventArgs> getCurrentBetsCompleted;
        GetCurrentBetsLiteResp getCurrentBetsLite(GetCurrentBetsLiteReq request);
        void getCurrentBetsLiteAsync(GetCurrentBetsLiteReq request);
        void getCurrentBetsLiteAsync(GetCurrentBetsLiteReq request, object userState);
        event EventHandler<getCurrentBetsLiteCompletedEventArgs> getCurrentBetsLiteCompleted;
        GetDetailedAvailableMktDepthResp getDetailAvailableMktDepth(GetDetailedAvailableMktDepthReq request);
        void getDetailAvailableMktDepthAsync(GetDetailedAvailableMktDepthReq request);
        void getDetailAvailableMktDepthAsync(GetDetailedAvailableMktDepthReq request, object userState);
        event EventHandler<getDetailAvailableMktDepthCompletedEventArgs> getDetailAvailableMktDepthCompleted;
        GetInPlayMarketsResp getInPlayMarkets(GetInPlayMarketsReq request);
        void getInPlayMarketsAsync(GetInPlayMarketsReq request);
        void getInPlayMarketsAsync(GetInPlayMarketsReq request, object userState);
        event EventHandler<getInPlayMarketsCompletedEventArgs> getInPlayMarketsCompleted;
        GetMarketResp getMarket(GetMarketReq request);
        void getMarketAsync(GetMarketReq request);
        void getMarketAsync(GetMarketReq request, object userState);
        event EventHandler<getMarketCompletedEventArgs> getMarketCompleted;
        GetMarketInfoResp getMarketInfo(GetMarketInfoReq request);
        void getMarketInfoAsync(GetMarketInfoReq request);
        void getMarketInfoAsync(GetMarketInfoReq request, object userState);
        event EventHandler<getMarketInfoCompletedEventArgs> getMarketInfoCompleted;
        GetMarketPricesResp getMarketPrices(GetMarketPricesReq request);
        void getMarketPricesAsync(GetMarketPricesReq request);
        void getMarketPricesAsync(GetMarketPricesReq request, object userState);
        event EventHandler<getMarketPricesCompletedEventArgs> getMarketPricesCompleted;
        GetMarketPricesCompressedResp getMarketPricesCompressed(GetMarketPricesCompressedReq request);
        void getMarketPricesCompressedAsync(GetMarketPricesCompressedReq request);
        void getMarketPricesCompressedAsync(GetMarketPricesCompressedReq request, object userState);
        event EventHandler<getMarketPricesCompressedCompletedEventArgs> getMarketPricesCompressedCompleted;
        GetMarketProfitAndLossResp getMarketProfitAndLoss(GetMarketProfitAndLossReq request);
        void getMarketProfitAndLossAsync(GetMarketProfitAndLossReq request);
        void getMarketProfitAndLossAsync(GetMarketProfitAndLossReq request, object userState);
        event EventHandler<getMarketProfitAndLossCompletedEventArgs> getMarketProfitAndLossCompleted;
        GetMarketTradedVolumeResp getMarketTradedVolume(GetMarketTradedVolumeReq request);
        void getMarketTradedVolumeAsync(GetMarketTradedVolumeReq request);
        void getMarketTradedVolumeAsync(GetMarketTradedVolumeReq request, object userState);
        event EventHandler<getMarketTradedVolumeCompletedEventArgs> getMarketTradedVolumeCompleted;
        GetMarketTradedVolumeCompressedResp getMarketTradedVolumeCompressed(GetMarketTradedVolumeCompressedReq request);
        void getMarketTradedVolumeCompressedAsync(GetMarketTradedVolumeCompressedReq request);
        void getMarketTradedVolumeCompressedAsync(GetMarketTradedVolumeCompressedReq request, object userState);
        event EventHandler<getMarketTradedVolumeCompressedCompletedEventArgs> getMarketTradedVolumeCompressedCompleted;
        GetMUBetsResp getMUBets(GetMUBetsReq request);
        void getMUBetsAsync(GetMUBetsReq request);
        void getMUBetsAsync(GetMUBetsReq request, object userState);
        event EventHandler<getMUBetsCompletedEventArgs> getMUBetsCompleted;
        GetMUBetsLiteResp getMUBetsLite(GetMUBetsLiteReq request);
        void getMUBetsLiteAsync(GetMUBetsLiteReq request);
        void getMUBetsLiteAsync(GetMUBetsLiteReq request, object userState);
        event EventHandler<getMUBetsLiteCompletedEventArgs> getMUBetsLiteCompleted;
        GetPrivateMarketsResp getPrivateMarkets(GetPrivateMarketsReq request);
        void getPrivateMarketsAsync(GetPrivateMarketsReq request);
        void getPrivateMarketsAsync(GetPrivateMarketsReq request, object userState);
        event EventHandler<getPrivateMarketsCompletedEventArgs> getPrivateMarketsCompleted;
        GetSilksResp getSilks(GetSilksReq request);
        void getSilksAsync(GetSilksReq request);
        void getSilksAsync(GetSilksReq request, object userState);
        event EventHandler<getSilksCompletedEventArgs> getSilksCompleted;
        GetSilksV2Resp getSilksV2(GetSilksV2Req request);
        void getSilksV2Async(GetSilksV2Req request);
        void getSilksV2Async(GetSilksV2Req request, object userState);
        event EventHandler<getSilksV2CompletedEventArgs> getSilksV2Completed;
        HeartbeatResp heartbeat(HeartbeatReq request);
        void heartbeatAsync(HeartbeatReq request);
        void heartbeatAsync(HeartbeatReq request, object userState);
        event EventHandler<heartbeatCompletedEventArgs> heartbeatCompleted;
        PlaceBetsResp placeBets(PlaceBetsReq request);
        void placeBetsAsync(PlaceBetsReq request);
        void placeBetsAsync(PlaceBetsReq request, object userState);
        event EventHandler<placeBetsCompletedEventArgs> placeBetsCompleted;
        UpdateBetsResp updateBets(UpdateBetsReq request);
        void updateBetsAsync(UpdateBetsReq request);
        void updateBetsAsync(UpdateBetsReq request, object userState);
        event EventHandler<updateBetsCompletedEventArgs> updateBetsCompleted;
    }
}