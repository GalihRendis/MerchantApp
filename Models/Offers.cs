using Microsoft.AspNetCore.Http;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MerchantApp.Models
{
    public class Offers : BaseModel
    {
        [Column("title")]
        public string Title { get; set; }

        [Column("slug")]
        public string Slug { get; set; }

        [Column("image")]
        public string Image { get; set; }

        [NotMapped]
        [Display(Name = "Upload Image")]
        public IFormFile ImageFile { get; set; }

        [Column("image_content")]
        public string ImageContent { get; set; }

        [NotMapped]
        [Display(Name = "Upload Image Content")]
        public IFormFile ImageContentFile { get; set; }

        [Column("description")]
        public string Description { get; set; }

        [Column("expired_at")]
        [Display(Name = "Expired At")]
        public DateTime? ExpiredAt { get; set; }

        // Friend Benefit
        [Column("friend_reward_type")]
        [Display(Name = "Friend Reward Type")]
        public int? FriendRewardType { get; set; }   // Benefit: diskon & tanpa benefit

        [Column("friend_reward_amount")]
        [Display(Name = "Friend Reward Amount")]
        public int? FriendRewardAmount { get; set; }

        [Column("friend_reward_is_percent")]
        [Display(Name = "Friend Reward Is Percent?")]
        public bool? FriendRewardIsPercent { get; set; }

        [Column("friend_reward_expired_at")]
        [Display(Name = "Friend Reward Expired At")]
        public DateTime? FriendRewardExpiredAt { get; set; }

        // Fan Benefit
        [Column("fan_reward_type")]
        [Display(Name = "Fan Reward Type")]
        public int? FanRewardType { get; set; }     // Benefit: komisi, undian, hadiah langsung

        [Column("fan_reward_amount")]
        [Display(Name = "Fan Reward Amount")]
        public int? FanRewardAmount { get; set; }   // Atribut untuk komisi

        [Column("fan_reward_label")]
        [Display(Name = "Fan Reward Label")]
        public string FanRewardLabel { get; set; }  // Atribut untuk undian dan hadiah langsung

        [Column("fan_rule_min_referral")]
        [Display(Name = "Fan Rule Min Referral")]
        public int? FanRuleMinReferral { get; set; }

        // Foreign Key - Merchants
        [Column("merchant_id")]
        [Display(Name = "Merchant Id")]
        public int MerchantsId { get; set; }
        public Merchants Merchants { get; set; }

        // Foreign Key - OffersCategories
        [Column("offer_category_id")]
        [Display(Name = "Offer Category Id")]
        public int OfferCategoriesId { get; set; }
        public OfferCategories OfferCategories { get; set; }

    }
}
