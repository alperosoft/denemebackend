﻿using Osoft.SiparisOnay.Core.DTO;
using System.ComponentModel.DataAnnotations;

namespace Osoft.SiparisOnay.Core.Models
{
    public class Mamlz: MamlzCmpt
    {
        [Key]
        public int mm_primno { get; set; }
        [Range(-32768, 32768, ErrorMessage = "Sayı 32768 değeri fazla olamaz.")]
        public int srk_no { get; set; } = 0;
        [Range(0, 255, ErrorMessage = "Sayı 255 den fazla olamaz.")]
        public int mm_tur { get; set; } = 0;
        [StringLength(20, ErrorMessage = "Karakter sayısı 20 aşmamalıdır.")]
        public string mm_kod { get; set; } = "";
        [StringLength(100, ErrorMessage = "Karakter sayısı 100 aşmamalıdır.")]
        public string mm_ad { get; set; } = "";
        [StringLength(50, ErrorMessage = "Karakter sayısı 50 aşmamalıdır.")]
        public string mm_cins { get; set; } = "";
        [StringLength(20, ErrorMessage = "Karakter sayısı 20 aşmamalıdır.")]
        public string mm_orjkod { get; set; } = "";
        [Range(-2147483648, 2147483647, ErrorMessage = "Sayı 10 karakterden fazla olamaz.")]
        public int mm_grp_primno { get; set; } = 0;
        [StringLength(10, ErrorMessage = "Karakter sayısı 10 aşmamalıdır.")]
        public string mm_grp { get; set; } = "";
        [Range(-2147483648, 2147483647, ErrorMessage = "Sayı 10 karakterden fazla olamaz.")]
        public int mm_grp1_primno { get; set; } = 0;
        [StringLength(8, ErrorMessage = "Karakter sayısı 8 aşmamalıdır.")]
        public string mm_grp1_kod { get; set; } = "";
        [StringLength(1, ErrorMessage = "Karakter sayısı 1 aşmamalıdır.")]
        public string mm_mlz_tur { get; set; } = "";
        [StringLength(1, ErrorMessage = "Karakter sayısı 1 aşmamalıdır.")]
        public string mm_brmgrp { get; set; } = "";
        [RegularExpression(@"^\d+.?\d{0,2}$", ErrorMessage = "Sayı virgülden sonra 2 haneli olmalıdır.")]
        [Range(0, 999.99, ErrorMessage = "Sayı 5 karakterden fazla olamaz.")]
        public decimal mm_boyacarp { get; set; } = 0;
        [StringLength(5, ErrorMessage = "Karakter sayısı 5 aşmamalıdır.")]
        public string mm_birim { get; set; } = "";
        [StringLength(5, ErrorMessage = "Karakter sayısı 5 aşmamalıdır.")]
        public string mm_birim2 { get; set; } = "";
        [StringLength(5, ErrorMessage = "Karakter sayısı 5 aşmamalıdır.")]
        public string mm_birim3 { get; set; } = "";
        [RegularExpression(@"^\d+.?\d{0,3}$", ErrorMessage = "Sayı virgülden sonra 3 haneli olmalıdır.")]
        [Range(0, 9999.999, ErrorMessage = "Sayı 7 karakterden fazla olamaz.")]
        public decimal mm_brmcarp { get; set; } = 0;
        [StringLength(20, ErrorMessage = "Karakter sayısı 20 aşmamalıdır.")]
        public string mm_stokyeri { get; set; } = "";
        [RegularExpression(@"^\d+.?\d{0,2}$", ErrorMessage = "Sayı virgülden sonra 2 haneli olmalıdır.")]
        [Range(0, 999.99, ErrorMessage = "Sayı 5 karakterden fazla olamaz.")]
        public decimal mm_fire { get; set; } = 0;
        [Range(-2147483648, 2147483647, ErrorMessage = "Sayı 10 karakterden fazla olamaz.")]
        public int mm_minstk { get; set; } = 0;
        [StringLength(20, ErrorMessage = "Karakter sayısı 20 aşmamalıdır.")]
        public string mm_ted_frm_kod { get; set; } = "";
        [Range(0, 255, ErrorMessage = "Sayı 255 den fazla olamaz.")]
        public int mm_kdv { get; set; } = 0;
        public DateTime? mm_alis_trh { get; set; } = null;
        [RegularExpression(@"^\d+.?\d{0,4}$", ErrorMessage = "Sayı virgülden sonra 4 haneli olmalıdır.")]
        [Range(0, 999999999999.9999, ErrorMessage = "Sayı 16 karakterden fazla olamaz.")]
        public decimal mm_alis_fiyat { get; set; } = 0;
        [StringLength(5, ErrorMessage = "Karakter sayısı 5 aşmamalıdır.")]
        public string mm_alis_dvz_kod { get; set; } = "";
        [RegularExpression(@"^\d+.?\d{0,4}$", ErrorMessage = "Sayı virgülden sonra 4 haneli olmalıdır.")]
        [Range(0, 999999999999.9999, ErrorMessage = "Sayı 16 karakterden fazla olamaz.")]
        public decimal mm_satis_fiyat { get; set; } = 0;
        [StringLength(5, ErrorMessage = "Karakter sayısı 5 aşmamalıdır.")]
        public string mm_satis_dvz_kod { get; set; } = "";
        [Range(0, 255, ErrorMessage = "Sayı 255 den fazla olamaz.")]
        public int mm_dp_no { get; set; } = 0;
        [RegularExpression(@"^\d+.?\d{0,2}$", ErrorMessage = "Sayı virgülden sonra 2 haneli olmalıdır.")]
        [Range(0, 99999.99, ErrorMessage = "Sayı 7 karakterden fazla olamaz.")]
        public decimal mm_grmj { get; set; } = 0;
        [RegularExpression(@"^\d+.?\d{0,2}$", ErrorMessage = "Sayı virgülden sonra 2 haneli olmalıdır.")]
        [Range(0, 999.99, ErrorMessage = "Sayı 5 karakterden fazla olamaz.")]
        public decimal mm_metretul { get; set; } = 0;
        [RegularExpression(@"^\d+.?\d{0,2}$", ErrorMessage = "Sayı virgülden sonra 2 haneli olmalıdır.")]
        [Range(0, 99999.99, ErrorMessage = "Sayı 7 karakterden fazla olamaz.")]
        public decimal mm_grmj2 { get; set; } = 0;
        [Range(-2147483648, 2147483647, ErrorMessage = "Sayı 10 karakterden fazla olamaz.")]
        public int mm_cl_primno { get; set; } = 0;
        [StringLength(20, ErrorMessage = "Karakter sayısı 20 aşmamalıdır.")]
        public string mm_cl_kod { get; set; } = "";
        [Range(-2147483648, 2147483647, ErrorMessage = "Sayı 10 karakterden fazla olamaz.")]
        public int mm_tlmt_primno { get; set; } = 0;
        [StringLength(20, ErrorMessage = "Karakter sayısı 20 aşmamalıdır.")]
        public string mm_tlmt_kod { get; set; } = "";
        [RegularExpression(@"^\d+.?\d{0,3}$", ErrorMessage = "Sayı virgülden sonra 3 haneli olmalıdır.")]
        [Range(0, 9999999.999, ErrorMessage = "Sayı 10 karakterden fazla olamaz.")]
        public decimal mm_kg_top { get; set; } = 0;
        [RegularExpression(@"^\d+.?\d{0,3}$", ErrorMessage = "Sayı virgülden sonra 3 haneli olmalıdır.")]
        [Range(0, 9999999.999, ErrorMessage = "Sayı 10 karakterden fazla olamaz.")]
        public decimal mm_kalinlik { get; set; } = 0;
        [RegularExpression(@"^\d+.?\d{0,4}$", ErrorMessage = "Sayı virgülden sonra 4 haneli olmalıdır.")]
        [Range(0, 999999.9999, ErrorMessage = "Sayı 10 karakterden fazla olamaz.")]
        public decimal mm_boy { get; set; } = 0;
        [RegularExpression(@"^\d+.?\d{0,4}$", ErrorMessage = "Sayı virgülden sonra 4 haneli olmalıdır.")]
        [Range(0, 999999.9999, ErrorMessage = "Sayı 10 karakterden fazla olamaz.")]
        public decimal mm_en { get; set; } = 0;
        [Range(-2147483648, 2147483647, ErrorMessage = "Sayı 10 karakterden fazla olamaz.")]
        public int mm_des_primno { get; set; } = 0;
        [StringLength(20, ErrorMessage = "Karakter sayısı 20 aşmamalıdır.")]
        public string mm_des_kod { get; set; } = "";
        [StringLength(8, ErrorMessage = "Karakter sayısı 8 aşmamalıdır.")]
        public string uk { get; set; } = "";
        public DateTime? updt { get; set; } = null;
        [StringLength(8, ErrorMessage = "Karakter sayısı 8 aşmamalıdır.")]
        public string iuk { get; set; } = "";
        public DateTime? idt { get; set; } = null;
        [StringLength(20, ErrorMessage = "Karakter sayısı 20 aşmamalıdır.")]
        public string mm_barkod { get; set; } = "";
        [StringLength(25, ErrorMessage = "Karakter sayısı 25 aşmamalıdır.")]
        public string mm_uretici { get; set; } = "";
        [StringLength(25, ErrorMessage = "Karakter sayısı 25 aşmamalıdır.")]
        public string mm_standart { get; set; } = "";
        [StringLength(100, ErrorMessage = "Karakter sayısı 100 aşmamalıdır.")]
        public string mm_ad_ydil { get; set; } = "";
        [StringLength(30, ErrorMessage = "Karakter sayısı 30 aşmamalıdır.")]
        public string mm_muh_sat_hesno { get; set; } = "";
        [StringLength(30, ErrorMessage = "Karakter sayısı 30 aşmamalıdır.")]
        public string mm_muh_stok_kod { get; set; } = "";
        [RegularExpression(@"^\d+.?\d{0,3}$", ErrorMessage = "Sayı virgülden sonra 3 haneli olmalıdır.")]
        [Range(0, 9999999.999, ErrorMessage = "Sayı 10 karakterden fazla olamaz.")]
        public decimal mm_mkt_kg { get; set; } = 0;
        [RegularExpression(@"^\d+.?\d{0,3}$", ErrorMessage = "Sayı virgülden sonra 3 haneli olmalıdır.")]
        [Range(0, 9999999.999, ErrorMessage = "Sayı 10 karakterden fazla olamaz.")]
        public decimal mm_bmkt_kg { get; set; } = 0;
        [StringLength(25, ErrorMessage = "Karakter sayısı 25 aşmamalıdır.")]
        public string mm_ipno { get; set; } = "";
        [Range(0, 255, ErrorMessage = "Sayı 255 den fazla olamaz.")]
        public int mm_oto_isrt { get; set; } = 0;
        [Range(0, 255, ErrorMessage = "Sayı 255 den fazla olamaz.")]
        public int mm_yok { get; set; } = 0;
        [Range(-2147483648, 2147483647, ErrorMessage = "Sayı 10 karakterden fazla olamaz.")]
        public int mm_i1 { get; set; } = 0;
        [Range(-2147483648, 2147483647, ErrorMessage = "Sayı 10 karakterden fazla olamaz.")]
        public int mm_i2 { get; set; } = 0;
        [Range(-2147483648, 2147483647, ErrorMessage = "Sayı 10 karakterden fazla olamaz.")]
        public int mm_i3 { get; set; } = 0;
        [StringLength(50, ErrorMessage = "Karakter sayısı 50 aşmamalıdır.")]
        public string mm_v1 { get; set; } = "";
        [StringLength(50, ErrorMessage = "Karakter sayısı 50 aşmamalıdır.")]
        public string mm_v2 { get; set; } = "";
        [StringLength(50, ErrorMessage = "Karakter sayısı 50 aşmamalıdır.")]
        public string mm_v3 { get; set; } = "";
        [StringLength(10, ErrorMessage = "Karakter sayısı 10 aşmamalıdır.")]
        public string mm_g1 { get; set; } = "";
        [StringLength(10, ErrorMessage = "Karakter sayısı 10 aşmamalıdır.")]
        public string mm_g2 { get; set; } = "";
        [StringLength(10, ErrorMessage = "Karakter sayısı 10 aşmamalıdır.")]
        public string mm_g3 { get; set; } = "";
        [StringLength(10, ErrorMessage = "Karakter sayısı 10 aşmamalıdır.")]
        public string mm_g4 { get; set; } = "";
        [StringLength(10, ErrorMessage = "Karakter sayısı 10 aşmamalıdır.")]
        public string mm_g5 { get; set; } = "";
        [StringLength(10, ErrorMessage = "Karakter sayısı 10 aşmamalıdır.")]
        public string mm_g6 { get; set; } = "";
        [StringLength(10, ErrorMessage = "Karakter sayısı 10 aşmamalıdır.")]
        public string mm_g7 { get; set; } = "";
        [StringLength(10, ErrorMessage = "Karakter sayısı 10 aşmamalıdır.")]
        public string mm_g8 { get; set; } = "";
        [StringLength(10, ErrorMessage = "Karakter sayısı 10 aşmamalıdır.")]
        public string mm_g9 { get; set; } = "";
        [StringLength(10, ErrorMessage = "Karakter sayısı 10 aşmamalıdır.")]
        public string mm_g10 { get; set; } = "";
        [StringLength(10, ErrorMessage = "Karakter sayısı 10 aşmamalıdır.")]
        public string mm_g11 { get; set; } = "";
        [StringLength(10, ErrorMessage = "Karakter sayısı 10 aşmamalıdır.")]
        public string mm_g12 { get; set; } = "";
        [StringLength(10, ErrorMessage = "Karakter sayısı 10 aşmamalıdır.")]
        public string mm_g13 { get; set; } = "";
        [StringLength(10, ErrorMessage = "Karakter sayısı 10 aşmamalıdır.")]
        public string mm_g14 { get; set; } = "";
        [RegularExpression(@"^\d+.?\d{0,4}$", ErrorMessage = "Sayı virgülden sonra 4 haneli olmalıdır.")]
        [Range(0, 99999999999999.9999, ErrorMessage = "Sayı 18 karakterden fazla olamaz.")]
        public decimal mm_tutar_b { get; set; } = 0;
        [RegularExpression(@"^\d+.?\d{0,4}$", ErrorMessage = "Sayı virgülden sonra 4 haneli olmalıdır.")]
        [Range(0, 99999999999999.9999, ErrorMessage = "Sayı 18 karakterden fazla olamaz.")]
        public decimal mm_tutar_a { get; set; } = 0;
        [StringLength(6, ErrorMessage = "Karakter sayısı 6 aşmamalıdır.")]
        public string mm_ab_kod { get; set; } = "";
        [StringLength(6, ErrorMessage = "Karakter sayısı 6 aşmamalıdır.")]
        public string mm_kap_band { get; set; } = "";
        [Range(-2147483648, 2147483647, ErrorMessage = "Sayı 10 karakterden fazla olamaz.")]
        public int mm_pul_vur { get; set; } = 0;
        [Range(-2147483648, 2147483647, ErrorMessage = "Sayı 10 karakterden fazla olamaz.")]
        public int mm_kord_vur { get; set; } = 0;
        [Range(-2147483648, 2147483647, ErrorMessage = "Sayı 10 karakterden fazla olamaz.")]
        public int mm_suz_vur { get; set; } = 0;
        [RegularExpression(@"^\d+.?\d{0,3}$", ErrorMessage = "Sayı virgülden sonra 3 haneli olmalıdır.")]
        [Range(0, 999999.999, ErrorMessage = "Sayı 9 karakterden fazla olamaz.")]
        public decimal mm_kasy_sol { get; set; } = 0;
        [RegularExpression(@"^\d+.?\d{0,3}$", ErrorMessage = "Sayı virgülden sonra 3 haneli olmalıdır.")]
        [Range(0, 999999.999, ErrorMessage = "Sayı 9 karakterden fazla olamaz.")]
        public decimal mm_kasy_sag { get; set; } = 0;
        [RegularExpression(@"^\d+.?\d{0,3}$", ErrorMessage = "Sayı virgülden sonra 3 haneli olmalıdır.")]
        [Range(0, 999999.999, ErrorMessage = "Sayı 9 karakterden fazla olamaz.")]
        public decimal mm_kasd_up { get; set; } = 0;
        [RegularExpression(@"^\d+.?\d{0,3}$", ErrorMessage = "Sayı virgülden sonra 3 haneli olmalıdır.")]
        [Range(0, 999999.999, ErrorMessage = "Sayı 9 karakterden fazla olamaz.")]
        public decimal mm_kasd_down { get; set; } = 0;
        [Range(-2147483648, 2147483647, ErrorMessage = "Sayı 10 karakterden fazla olamaz.")]
        public int mm_devir { get; set; } = 0;
        [Range(-2147483648, 2147483647, ErrorMessage = "Sayı 10 karakterden fazla olamaz.")]
        public int mm_ip_kes { get; set; } = 0;
        [Range(-2147483648, 2147483647, ErrorMessage = "Sayı 10 karakterden fazla olamaz.")]
        public int mm_pul_devir { get; set; } = 0;
        [Range(-2147483648, 2147483647, ErrorMessage = "Sayı 10 karakterden fazla olamaz.")]
        public int mm_kord_devir { get; set; } = 0;
        [Range(-2147483648, 2147483647, ErrorMessage = "Sayı 10 karakterden fazla olamaz.")]
        public int mm_suzme_devir { get; set; } = 0;
        [Range(-32768, 32768, ErrorMessage = "Sayı 32768 değeri fazla olamaz.")]
        public int mm_kumas_ger { get; set; } = 0;
        [Range(-32768, 32768, ErrorMessage = "Sayı 32768 değeri fazla olamaz.")]
        public int mm_kas_cevir { get; set; } = 0;
        [Range(-32768, 32768, ErrorMessage = "Sayı 32768 değeri fazla olamaz.")]
        public int mm_mekik_degis { get; set; } = 0;
        [RegularExpression(@"^\d+.?\d{0,2}$", ErrorMessage = "Sayı virgülden sonra 2 haneli olmalıdır.")]
        [Range(0, 999999.99, ErrorMessage = "Sayı 8 karakterden fazla olamaz.")]
        public decimal mm_ciz_mly { get; set; } = 0;
        [RegularExpression(@"^\d+.?\d{0,2}$", ErrorMessage = "Sayı virgülden sonra 2 haneli olmalıdır.")]
        [Range(0, 999999.99, ErrorMessage = "Sayı 8 karakterden fazla olamaz.")]
        public decimal mm_punch_mly { get; set; } = 0;
        public DateTime? mm_ciz_trh { get; set; } = null;
        public DateTime? mm_punch_trh { get; set; } = null;
        [Range(-2147483648, 2147483647, ErrorMessage = "Sayı 10 karakterden fazla olamaz.")]
        public int mm_per_ciz { get; set; } = 0;
        [Range(-2147483648, 2147483647, ErrorMessage = "Sayı 10 karakterden fazla olamaz.")]
        public int mm_per_punch { get; set; } = 0;
        [StringLength(30, ErrorMessage = "Karakter sayısı 30 aşmamalıdır.")]
        public string mm_tas_no { get; set; } = "";
        [StringLength(12, ErrorMessage = "Karakter sayısı 12 aşmamalıdır.")]
        public string mm_mak_kod { get; set; } = "";
        [StringLength(30, ErrorMessage = "Karakter sayısı 30 aşmamalıdır.")]
        public string mm_muh_akod { get; set; } = "";
        [Range(0, 255, ErrorMessage = "Sayı 255 den fazla olamaz.")]
        public int mm_demirbas { get; set; } = 0;
        [StringLength(50, ErrorMessage = "Karakter sayısı 50 aşmamalıdır.")]
        public string mm_demirbas_kod { get; set; } = "";
        [Range(-32768, 32768, ErrorMessage = "Sayı 32768 değeri fazla olamaz.")]
        public int mm_amortis_tur { get; set; } = 0;
        [Range(-32768, 32768, ErrorMessage = "Sayı 32768 değeri fazla olamaz.")]
        public int mm_amortis_sure { get; set; } = 0;
        [Range(-32768, 32768, ErrorMessage = "Sayı 32768 değeri fazla olamaz.")]
        public int mm_amortis_hurda_sure { get; set; } = 0;
        [StringLength(50, ErrorMessage = "Karakter sayısı 50 aşmamalıdır.")]
        public string mm_gtip_kod { get; set; } = "";
        [RegularExpression(@"^\d+.?\d{0,6}$", ErrorMessage = "Sayı virgülden sonra 6 haneli olmalıdır.")]
        [Range(0, 9999999999.999999, ErrorMessage = "Sayı 16 karakterden fazla olamaz.")]
        public decimal mm_stk_mkt_gir { get; set; } = 0;
        [RegularExpression(@"^\d+.?\d{0,6}$", ErrorMessage = "Sayı virgülden sonra 6 haneli olmalıdır.")]
        [Range(0, 9999999999.999999, ErrorMessage = "Sayı 16 karakterden fazla olamaz.")]
        public decimal mm_stk_mkt_cik { get; set; } = 0;
        [RegularExpression(@"^\d+.?\d{0,6}$", ErrorMessage = "Sayı virgülden sonra 6 haneli olmalıdır.")]
        [Range(0, 9999999999.999999, ErrorMessage = "Sayı 16 karakterden fazla olamaz.")]
        public decimal mm_stk_mkt_mt_gir { get; set; } = 0;
        [RegularExpression(@"^\d+.?\d{0,6}$", ErrorMessage = "Sayı virgülden sonra 6 haneli olmalıdır.")]
        [Range(0, 9999999999.999999, ErrorMessage = "Sayı 16 karakterden fazla olamaz.")]
        public decimal mm_stk_mkt_mt_cik { get; set; } = 0;
        [RegularExpression(@"^\d+.?\d{0,6}$", ErrorMessage = "Sayı virgülden sonra 6 haneli olmalıdır.")]
        [Range(0, 9999999999.999999, ErrorMessage = "Sayı 16 karakterden fazla olamaz.")]
        public decimal mm_stk_mkt_amb_gir { get; set; } = 0;
        [RegularExpression(@"^\d+.?\d{0,6}$", ErrorMessage = "Sayı virgülden sonra 6 haneli olmalıdır.")]
        [Range(0, 9999999999.999999, ErrorMessage = "Sayı 16 karakterden fazla olamaz.")]
        public decimal mm_stk_mkt_amb_cik { get; set; } = 0;
        [StringLength(20, ErrorMessage = "Karakter sayısı 20 aşmamalıdır.")]
        public string mm_yuzey { get; set; } = "";
        [StringLength(20, ErrorMessage = "Karakter sayısı 20 aşmamalıdır.")]
        public string mm_boya_kalite { get; set; } = "";
        [StringLength(20, ErrorMessage = "Karakter sayısı 20 aşmamalıdır.")]
        public string mm_coz_kod { get; set; } = "";
        [Range(-2147483648, 2147483647, ErrorMessage = "Sayı 10 karakterden fazla olamaz.")]
        public int mm_tarak_no { get; set; } = 0;
        [Range(-2147483648, 2147483647, ErrorMessage = "Sayı 10 karakterden fazla olamaz.")]
        public int mm_dis_tel { get; set; } = 0;
        [Range(-2147483648, 2147483647, ErrorMessage = "Sayı 10 karakterden fazla olamaz.")]
        public int mm_coz_sklik { get; set; } = 0;
        [Range(-2147483648, 2147483647, ErrorMessage = "Sayı 10 karakterden fazla olamaz.")]
        public int mm_kenar_tel { get; set; } = 0;
        [Range(-2147483648, 2147483647, ErrorMessage = "Sayı 10 karakterden fazla olamaz.")]
        public int mm_coz_buz { get; set; } = 0;
        [Range(-2147483648, 2147483647, ErrorMessage = "Sayı 10 karakterden fazla olamaz.")]
        public int mm_coz_fazla { get; set; } = 0;
        [Range(-2147483648, 2147483647, ErrorMessage = "Sayı 10 karakterden fazla olamaz.")]
        public int mm_kumas_coz_sklik { get; set; } = 0;
        [RegularExpression(@"^\d+.?\d{0,3}$", ErrorMessage = "Sayı virgülden sonra 3 haneli olmalıdır.")]
        [Range(0, 9999999.999, ErrorMessage = "Sayı 10 karakterden fazla olamaz.")]
        public decimal mm_hasil_al_oran { get; set; } = 0;
        [Range(-2147483648, 2147483647, ErrorMessage = "Sayı 10 karakterden fazla olamaz.")]
        public int mm_cozgu_rapor_en { get; set; } = 0;
        [RegularExpression(@"^\d+.?\d{0,3}$", ErrorMessage = "Sayı virgülden sonra 3 haneli olmalıdır.")]
        [Range(0, 9999999.999, ErrorMessage = "Sayı 10 karakterden fazla olamaz.")]
        public decimal mm_tarak_en { get; set; } = 0;
        [RegularExpression(@"^\d+.?\d{0,3}$", ErrorMessage = "Sayı virgülden sonra 3 haneli olmalıdır.")]
        [Range(0, 9999999.999, ErrorMessage = "Sayı 10 karakterden fazla olamaz.")]
        public decimal mm_coz_hen { get; set; } = 0;
        [RegularExpression(@"^\d+.?\d{0,3}$", ErrorMessage = "Sayı virgülden sonra 3 haneli olmalıdır.")]
        [Range(0, 9999999.999, ErrorMessage = "Sayı 10 karakterden fazla olamaz.")]
        public decimal mm_coz_men { get; set; } = 0;
        [RegularExpression(@"^\d+.?\d{0,3}$", ErrorMessage = "Sayı virgülden sonra 3 haneli olmalıdır.")]
        [Range(0, 9999999.999, ErrorMessage = "Sayı 10 karakterden fazla olamaz.")]
        public decimal mm_coz_hgr { get; set; } = 0;
        [RegularExpression(@"^\d+.?\d{0,3}$", ErrorMessage = "Sayı virgülden sonra 3 haneli olmalıdır.")]
        [Range(0, 9999999.999, ErrorMessage = "Sayı 10 karakterden fazla olamaz.")]
        public decimal mm_coz_mgr { get; set; } = 0;
        [RegularExpression(@"^\d+.?\d{0,3}$", ErrorMessage = "Sayı virgülden sonra 3 haneli olmalıdır.")]
        [Range(0, 9999999.999, ErrorMessage = "Sayı 10 karakterden fazla olamaz.")]
        public decimal mm_coz_tel { get; set; } = 0;
        [RegularExpression(@"^\d+.?\d{0,3}$", ErrorMessage = "Sayı virgülden sonra 3 haneli olmalıdır.")]
        [Range(0, 9999999.999, ErrorMessage = "Sayı 10 karakterden fazla olamaz.")]
        public decimal mm_coz_rapor_tel { get; set; } = 0;
        [StringLength(100, ErrorMessage = "Karakter sayısı 100 aşmamalıdır.")]
        public string mm_orgu_sekli { get; set; } = "";
        [Range(-2147483648, 2147483647, ErrorMessage = "Sayı 10 karakterden fazla olamaz.")]
        public int mm_atki_sklik { get; set; } = 0;
        [RegularExpression(@"^\d+.?\d{0,3}$", ErrorMessage = "Sayı virgülden sonra 3 haneli olmalıdır.")]
        [Range(0, 9999999.999, ErrorMessage = "Sayı 10 karakterden fazla olamaz.")]
        public decimal mm_atki_buz { get; set; } = 0;
        [Range(-2147483648, 2147483647, ErrorMessage = "Sayı 10 karakterden fazla olamaz.")]
        public int mm_atki_fazla { get; set; } = 0;
        [RegularExpression(@"^\d+.?\d{0,3}$", ErrorMessage = "Sayı virgülden sonra 3 haneli olmalıdır.")]
        [Range(0, 9999999.999, ErrorMessage = "Sayı 10 karakterden fazla olamaz.")]
        public decimal mm_atki_ort_sklik { get; set; } = 0;
        [RegularExpression(@"^\d+.?\d{0,3}$", ErrorMessage = "Sayı virgülden sonra 3 haneli olmalıdır.")]
        [Range(0, 9999999.999, ErrorMessage = "Sayı 10 karakterden fazla olamaz.")]
        public decimal mm_atki_mam_sklik { get; set; } = 0;
        [Range(-2147483648, 2147483647, ErrorMessage = "Sayı 10 karakterden fazla olamaz.")]
        public int mm_atki_devir { get; set; } = 0;
        [Range(-2147483648, 2147483647, ErrorMessage = "Sayı 10 karakterden fazla olamaz.")]
        public int mm_atki_rapor_boy { get; set; } = 0;
        [StringLength(100, ErrorMessage = "Karakter sayısı 100 aşmamalıdır.")]
        public string mm_aciklama1 { get; set; } = "";
        [StringLength(100, ErrorMessage = "Karakter sayısı 100 aşmamalıdır.")]
        public string mm_aciklama2 { get; set; } = "";
        [Range(-2147483648, 2147483647, ErrorMessage = "Sayı 10 karakterden fazla olamaz.")]
        public int mm_atki_rapor_tel_sayisi { get; set; } = 0;
        [StringLength(20, ErrorMessage = "Karakter sayısı 20 aşmamalıdır.")]
        public string mm_tahar_kodu { get; set; } = "";
        [StringLength(20, ErrorMessage = "Karakter sayısı 20 aşmamalıdır.")]
        public string mm_armur_kodu { get; set; } = "";
        [StringLength(200, ErrorMessage = "Karakter sayısı 200 aşmamalıdır.")]
        public string mm_satici { get; set; } = "";
        [RegularExpression(@"^\d+.?\d{0,4}$", ErrorMessage = "Sayı virgülden sonra 4 haneli olmalıdır.")]
        [Range(0, 999999999999.9999, ErrorMessage = "Sayı 16 karakterden fazla olamaz.")]
        public decimal mm_alis_trh_kur { get; set; } = 0;
        [Range(-2147483648, 2147483647, ErrorMessage = "Sayı 10 karakterden fazla olamaz.")]
        public int mm_gayrimenkul { get; set; } = 0;
        [RegularExpression(@"^\d+.?\d{0,6}$", ErrorMessage = "Sayı virgülden sonra 6 haneli olmalıdır.")]
        [Range(0, 999999999999.999999, ErrorMessage = "Sayı 18 karakterden fazla olamaz.")]
        public decimal mm_amortisman { get; set; } = 0;
        [Range(-2147483648, 2147483647, ErrorMessage = "Sayı 10 karakterden fazla olamaz.")]
        public int mm_kistalyum { get; set; } = 0;
        [Range(-2147483648, 2147483647, ErrorMessage = "Sayı 10 karakterden fazla olamaz.")]
        public int mm_sp_id { get; set; } = 0;
        [Range(-32768, 32768, ErrorMessage = "Sayı 32768 değeri fazla olamaz.")]
        public int mm_sp_no1 { get; set; } = 0;
        [Range(-2147483648, 2147483647, ErrorMessage = "Sayı 10 karakterden fazla olamaz.")]
        public int mm_sp_no2 { get; set; } = 0;
        [Range(-2147483648, 2147483647, ErrorMessage = "Sayı 10 karakterden fazla olamaz.")]
        public int mm_tesv_id { get; set; } = 0;
        [Range(-2147483648, 2147483647, ErrorMessage = "Sayı 10 karakterden fazla olamaz.")]
        public int mm_tesv_no { get; set; } = 0;
        [Range(-2147483648, 2147483647, ErrorMessage = "Sayı 10 karakterden fazla olamaz.")]
        public int mm_finansal_kira_no { get; set; } = 0;
        [StringLength(20, ErrorMessage = "Karakter sayısı 20 aşmamalıdır.")]
        public string mm_masraf_merkezi { get; set; } = "";
        [StringLength(20, ErrorMessage = "Karakter sayısı 20 aşmamalıdır.")]
        public string mm_belge_no { get; set; } = "";
        [Range(-2147483648, 2147483647, ErrorMessage = "Sayı 10 karakterden fazla olamaz.")]
        public int mm_ted_gun { get; set; } = 0;
        [StringLength(20, ErrorMessage = "Karakter sayısı 20 aşmamalıdır.")]
        public string mm_alasim { get; set; } = "";
        [StringLength(20, ErrorMessage = "Karakter sayısı 20 aşmamalıdır.")]
        public string mm_termik { get; set; } = "";
        [Range(-32768, 32768, ErrorMessage = "Sayı 32768 değeri fazla olamaz.")]
        public int mm_yil { get; set; } = 0;
        [Range(-2147483648, 2147483647, ErrorMessage = "Sayı 10 karakterden fazla olamaz.")]
        public int mm_res_en { get; set; } = 0;
        [Range(-2147483648, 2147483647, ErrorMessage = "Sayı 10 karakterden fazla olamaz.")]
        public int mm_res_boy { get; set; } = 0;
        [RegularExpression(@"^\d+.?\d{0,4}$", ErrorMessage = "Sayı virgülden sonra 4 haneli olmalıdır.")]
        [Range(0, 999999999999.9999, ErrorMessage = "Sayı 16 karakterden fazla olamaz.")]
        public decimal mm_alis_ilk_fiyat { get; set; } = 0;
        [RegularExpression(@"^\d+.?\d{0,4}$", ErrorMessage = "Sayı virgülden sonra 4 haneli olmalıdır.")]
        [Range(0, 999999999999.9999, ErrorMessage = "Sayı 16 karakterden fazla olamaz.")]
        public decimal mm_alis_mkt { get; set; } = 0;
        [Range(-2147483648, 2147483647, ErrorMessage = "Sayı 10 karakterden fazla olamaz.")]
        public int mm_mas_id { get; set; } = 0;
        public MamlzYardimCmpt? mamlzYardimCmpt {  get; set; }

        public Firma? firma { get; set; }

    }

    public class MamlzCmpt
    {
        public string cmpt_grp { get; set; }
        public int cmpt_rct { get; set; }
        public string cmpt_ipno { get; set; }
    }
}
