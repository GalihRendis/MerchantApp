using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MerchantApp.Models
{
    public class Offers : BaseModel
    {
        [Column("title")]
        public string Title { get; set; }
        [Column("description")]
        public string Description { get; set; }
        [Column("status")]
        public string Status { get; set; }
        [Column("image")]
        public string Image { get; set; }
        [Column("expired_at")]
        [Display(Name = "Expired At")]
        public DateTime ExpiredAt { get; set; }

        // Friend Benefit
        [Column("friend_reward_type")]
        [Display(Name = "Friend Reward Type")]
        public int FriendRewardType { get; set; }
        [Column("friend_reward_label")]
        [Display(Name = "Friend Reward Label")]
        public string FriendRewardLabel { get; set; }
        [Column("friend_reward_discount")]
        [Display(Name = "Friend Reward Discount")]
        public int FriendRewardDiscount { get; set; }
        [Column("friend_reward_discount_is_percent")]
        [Display(Name = "Friend Reward Discount Is Percent")]
        public bool FriendRewardDiscountIsPercent { get; set; }
        [Column("friend_reward_expired_at")]
        [Display(Name = "Friend Reward Expired At")]
        public DateTime FriendRewardExpiredAt { get; set; }

        // Fan Benefit
        [Column("fan_reward_type")]
        [Display(Name = "Fan Reward Type")]
        public int FanRewardType { get; set; }
        [Column("fan_reward_label")]
        [Display(Name = "Fan Reward Label")]
        public string FanRewardLabel { get; set; }
        [Column("fan_reward_amount")]
        [Display(Name = "Fan Reward Amount")]
        public int FanRewardAmount { get; set; }
        [Column("fan_reward_amount_is_percent")]
        [Display(Name = "Fan Amount Is Percent")]
        public bool FanRewardAmountIsPercent { get; set; }
        [Column("fan_rule_min_referral")]
        [Display(Name = "Fan Rule Minimum Referral")]
        public int FanRuleMinReferral { get; set; }
        [Column("fan_rule_min_friend_referral")]
        [Display(Name = "Fan Rule Minimum Friend Referral")]
        public int FanRuleMinFriendReferral { get; set; }

        // Foreign Key - Merchants
        [Column("merchant_id")]
        [Display(Name = "Merchant Id")]
        public int MerchantsId { get; set; }
        public Merchants Merchants { get; set; }

        // Foreign Key - OffersCategory
        [Column("offer_category_id")]
        [Display(Name = "Offer Category Id")]
        public int OfferCategoriesId { get; set; }
        public OfferCategories OfferCategories { get; set; }

    }
}
