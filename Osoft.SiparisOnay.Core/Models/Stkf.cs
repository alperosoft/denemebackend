﻿using System.ComponentModel.DataAnnotations;

namespace Osoft.SiparisOnay.Core.Models
{
    public class Stkf : StkfCmpt
    {
        [Range(-2147483648, 2147483647, ErrorMessage = "Sayı 10 karakterden fazla olamaz.")]
        [Required(ErrorMessage = "sf_primno  boş olamaz!")]
        public int sf_primno { get; set; }
        [Range(-32768, 32768, ErrorMessage = "Sayı 32768 değeri fazla olamaz.")]
        public int sf_srk_no { get; set; } = 0;
        [Range(-32768, 32768, ErrorMessage = "Sayı 32768 değeri fazla olamaz.")]
        public int sf_bcmno { get; set; } = 0;
        [Range(-32768, 32768, ErrorMessage = "Sayı 32768 değeri fazla olamaz.")]
        public int sf_yil { get; set; } = 0;
        [StringLength(10, ErrorMessage = "Karakter sayısı 10 aşmamalıdır.")]
        public string sf_seri { get; set; } = "";
        [Range(0, 255, ErrorMessage = "Sayı 255 den fazla olamaz.")]
        public int sf_dp_no { get; set; } = 0;
        [Range(-32768, 32768, ErrorMessage = "Sayı 32768 değeri fazla olamaz.")]
        public int sf_no1 { get; set; } = 0;
        [Range(-2147483648, 2147483647, ErrorMessage = "Sayı 10 karakterden fazla olamaz.")]
        public int sf_no2 { get; set; } = 0;
        public DateTime? sf_trh { get; set; } = null;
        [Range(0, 255, ErrorMessage = "Sayı 255 den fazla olamaz.")]
        public int sf_ay { get; set; } = 0;
        [Range(0, 255, ErrorMessage = "Sayı 255 den fazla olamaz.")]
        public int sf_fist_no { get; set; } = 0;
        [StringLength(20, ErrorMessage = "Karakter sayısı 20 aşmamalıdır.")]
        public string sf_frm_kod { get; set; } = "";
        [Range(-2147483648, 2147483647, ErrorMessage = "Sayı 10 karakterden fazla olamaz.")]
        public int sf_dept_no { get; set; } = 0;
        [StringLength(20, ErrorMessage = "Karakter sayısı 20 aşmamalıdır.")]
        public string sf_irs_frm_kod { get; set; } = "";
        [StringLength(10, ErrorMessage = "Karakter sayısı 10 aşmamalıdır.")]
        public string sf_irs_seri { get; set; } = "";
        [Range(-2147483648, 2147483647, ErrorMessage = "Sayı 10 karakterden fazla olamaz.")]
        public int sf_irs_no { get; set; } = 0;
        public DateTime? sf_irs_trh { get; set; } = null;
        [StringLength(25, ErrorMessage = "Karakter sayısı 25 aşmamalıdır.")]
        public string sf_teslim { get; set; } = "";
        [StringLength(15, ErrorMessage = "Karakter sayısı 15 aşmamalıdır.")]
        public string sf_plaka { get; set; } = "";
        [StringLength(300, ErrorMessage = "Karakter sayısı 300 aşmamalıdır.")]
        public string sf_aciklama { get; set; } = "";
        [StringLength(40, ErrorMessage = "Karakter sayısı 40 aşmamalıdır.")]
        public string sf_sys_str1 { get; set; } = "";
        [StringLength(40, ErrorMessage = "Karakter sayısı 40 aşmamalıdır.")]
        public string sf_sys_str2 { get; set; } = "";
        [StringLength(40, ErrorMessage = "Karakter sayısı 40 aşmamalıdır.")]
        public string sf_sys_str3 { get; set; } = "";
        [StringLength(40, ErrorMessage = "Karakter sayısı 40 aşmamalıdır.")]
        public string sf_sys_str4 { get; set; } = "";
        [StringLength(40, ErrorMessage = "Karakter sayısı 40 aşmamalıdır.")]
        public string sf_sys_str5 { get; set; } = "";
        [Range(-2147483648, 2147483647, ErrorMessage = "Sayı 10 karakterden fazla olamaz.")]
        public int sf_sys_no1 { get; set; } = 0;
        [Range(-2147483648, 2147483647, ErrorMessage = "Sayı 10 karakterden fazla olamaz.")]
        public int sf_sys_no2 { get; set; } = 0;
        [Range(-2147483648, 2147483647, ErrorMessage = "Sayı 10 karakterden fazla olamaz.")]
        public int sf_sys_no3 { get; set; } = 0;
        [Range(-2147483648, 2147483647, ErrorMessage = "Sayı 10 karakterden fazla olamaz.")]
        public int sf_sys_no4 { get; set; } = 0;
        [Range(-2147483648, 2147483647, ErrorMessage = "Sayı 10 karakterden fazla olamaz.")]
        public int sf_sys_no5 { get; set; } = 0;
        [StringLength(8, ErrorMessage = "Karakter sayısı 8 aşmamalıdır.")]
        public string uk { get; set; } = "";
        public DateTime? updt { get; set; } = null;
        [StringLength(8, ErrorMessage = "Karakter sayısı 8 aşmamalıdır.")]
        public string iuk { get; set; } = "";
        public DateTime? idt { get; set; } = null;
        [Range(-2147483648, 2147483647, ErrorMessage = "Sayı 10 karakterden fazla olamaz.")]
        public int sf_belgeno { get; set; } = 0;
        public DateTime? sf_belge_trh { get; set; } = null;
        [StringLength(12, ErrorMessage = "Karakter sayısı 12 aşmamalıdır.")]
        public string sf_mak_kod { get; set; } = "";
        [StringLength(2, ErrorMessage = "Karakter sayısı 2 aşmamalıdır.")]
        public string sf_vardiya { get; set; } = "";
        [Range(-2147483648, 2147483647, ErrorMessage = "Sayı 10 karakterden fazla olamaz.")]
        public int sf_per_no { get; set; } = 0;
        [StringLength(5, ErrorMessage = "Karakter sayısı 5 aşmamalıdır.")]
        public string sf_belge_seri { get; set; } = "";
        [Range(0, 255, ErrorMessage = "Sayı 255 den fazla olamaz.")]
        public int sf_fat_isaret { get; set; } = 0;
        [StringLength(1, ErrorMessage = "Karakter sayısı 1 aşmamalıdır.")]
        public string sf_fat_kapa { get; set; } = "";
        [StringLength(1, ErrorMessage = "Karakter sayısı 1 aşmamalıdır.")]
        public string sf_fat_tevkifat { get; set; } = "";
        [StringLength(4, ErrorMessage = "Karakter sayısı 4 aşmamalıdır.")]
        public string sf_fat_ft_kod { get; set; } = "";
        [Range(0, 255, ErrorMessage = "Sayı 255 den fazla olamaz.")]
        public int sf_ff_isaret { get; set; } = 0;
        [RegularExpression(@"^\d+.?\d{0,6}$", ErrorMessage = "Sayı virgülden sonra 6 haneli olmalıdır.")]
        [Range(0, 999999999999.999999, ErrorMessage = "Sayı 18 karakterden fazla olamaz.")]
        public decimal sf_brut_tutar { get; set; } = 0;
        [RegularExpression(@"^\d+.?\d{0,6}$", ErrorMessage = "Sayı virgülden sonra 6 haneli olmalıdır.")]
        [Range(0, 999999999999.999999, ErrorMessage = "Sayı 18 karakterden fazla olamaz.")]
        public decimal sf_isk_tutar { get; set; } = 0;
        [RegularExpression(@"^\d+.?\d{0,6}$", ErrorMessage = "Sayı virgülden sonra 6 haneli olmalıdır.")]
        [Range(0, 999999999999.999999, ErrorMessage = "Sayı 18 karakterden fazla olamaz.")]
        public decimal sf_tutar { get; set; } = 0;
        [RegularExpression(@"^\d+.?\d{0,6}$", ErrorMessage = "Sayı virgülden sonra 6 haneli olmalıdır.")]
        [Range(0, 999999999999.999999, ErrorMessage = "Sayı 18 karakterden fazla olamaz.")]
        public decimal sf_kdv_tutar { get; set; } = 0;
        [Range(-32768, 32768, ErrorMessage = "Sayı 32768 değeri fazla olamaz.")]
        public int sf_sft_tur { get; set; } = 0;
        [Range(-32768, 32768, ErrorMessage = "Sayı 32768 değeri fazla olamaz.")]
        public int sf_sfta_tur { get; set; } = 0;
        [StringLength(1, ErrorMessage = "Karakter sayısı 1 aşmamalıdır.")]
        public string sf_ba { get; set; } = "";
        [RegularExpression(@"^\d+.?\d{0,6}$", ErrorMessage = "Sayı virgülden sonra 6 haneli olmalıdır.")]
        [Range(0, 999999999999.999999, ErrorMessage = "Sayı 18 karakterden fazla olamaz.")]
        public decimal sf_tutar_b { get; set; } = 0;
        [RegularExpression(@"^\d+.?\d{0,6}$", ErrorMessage = "Sayı virgülden sonra 6 haneli olmalıdır.")]
        [Range(0, 999999999999.999999, ErrorMessage = "Sayı 18 karakterden fazla olamaz.")]
        public decimal sf_tutar_a { get; set; } = 0;
        [StringLength(5, ErrorMessage = "Karakter sayısı 5 aşmamalıdır.")]
        public string sf_dvz_kod_takip { get; set; } = "";
        [RegularExpression(@"^\d+.?\d{0,6}$", ErrorMessage = "Sayı virgülden sonra 6 haneli olmalıdır.")]
        [Range(0, 999999999999.999999, ErrorMessage = "Sayı 18 karakterden fazla olamaz.")]
        public decimal sf_tutar_takip_b { get; set; } = 0;
        [RegularExpression(@"^\d+.?\d{0,6}$", ErrorMessage = "Sayı virgülden sonra 6 haneli olmalıdır.")]
        [Range(0, 999999999999.999999, ErrorMessage = "Sayı 18 karakterden fazla olamaz.")]
        public decimal sf_tutar_takip_a { get; set; } = 0;
        public DateTime? sf_kur_trh { get; set; } = null;
        [RegularExpression(@"^\d+.?\d{0,10}$", ErrorMessage = "Sayı virgülden sonra 10 haneli olmalıdır.")]
        [Range(0, 99999999.9999999999, ErrorMessage = "Sayı 18 karakterden fazla olamaz.")]
        public decimal sf_kur { get; set; } = 0;
        [StringLength(8, ErrorMessage = "Karakter sayısı 8 aşmamalıdır.")]
        public string sf_ban_kod { get; set; } = "";
        [StringLength(25, ErrorMessage = "Karakter sayısı 25 aşmamalıdır.")]
        public string sf_sube { get; set; } = "";
        public DateTime? sf_valor { get; set; } = null;
        [Range(-32768, 32768, ErrorMessage = "Sayı 32768 değeri fazla olamaz.")]
        public int sf_vade { get; set; } = 0;
        [StringLength(25, ErrorMessage = "Karakter sayısı 25 aşmamalıdır.")]
        public string sf_keside { get; set; } = "";
        [StringLength(6, ErrorMessage = "Karakter sayısı 6 aşmamalıdır.")]
        public string sf_durum { get; set; } = "";
        [StringLength(50, ErrorMessage = "Karakter sayısı 50 aşmamalıdır.")]
        public string sf_belge_iye { get; set; } = "";
        [StringLength(100, ErrorMessage = "Karakter sayısı 100 aşmamalıdır.")]
        public string sf_aciklama2 { get; set; } = "";
        [StringLength(8, ErrorMessage = "Karakter sayısı 8 aşmamalıdır.")]
        public string sf_ban_kod2 { get; set; } = "";
        [Range(-2147483648, 2147483647, ErrorMessage = "Sayı 10 karakterden fazla olamaz.")]
        public int sf_primno2 { get; set; } = 0;
        [StringLength(1, ErrorMessage = "Karakter sayısı 1 aşmamalıdır.")]
        public string sf_bitis { get; set; } = "";
        [StringLength(6, ErrorMessage = "Karakter sayısı 6 aşmamalıdır.")]
        public string sf_ks_kod { get; set; } = "";
        [StringLength(25, ErrorMessage = "Karakter sayısı 25 aşmamalıdır.")]
        public string sf_banh_hesno { get; set; } = "";
        [StringLength(25, ErrorMessage = "Karakter sayısı 25 aşmamalıdır.")]
        public string sf_banh_hesno2 { get; set; } = "";
        [StringLength(6, ErrorMessage = "Karakter sayısı 6 aşmamalıdır.")]
        public string sf_ks_kod2 { get; set; } = "";
        [Range(-32768, 32768, ErrorMessage = "Sayı 32768 değeri fazla olamaz.")]
        public int sf_bcmno_2 { get; set; } = 0;
        [Range(-32768, 32768, ErrorMessage = "Sayı 32768 değeri fazla olamaz.")]
        public int sf_no1_2 { get; set; } = 0;
        [Range(-2147483648, 2147483647, ErrorMessage = "Sayı 10 karakterden fazla olamaz.")]
        public int sf_no2_2 { get; set; } = 0;
        [StringLength(12, ErrorMessage = "Karakter sayısı 12 aşmamalıdır.")]
        public string sf_partino { get; set; } = "";
        [StringLength(25, ErrorMessage = "Karakter sayısı 25 aşmamalıdır.")]
        public string sf_banka { get; set; } = "";
        [StringLength(25, ErrorMessage = "Karakter sayısı 25 aşmamalıdır.")]
        public string sf_cekno { get; set; } = "";
        [StringLength(30, ErrorMessage = "Karakter sayısı 30 aşmamalıdır.")]
        public string sf_vergida { get; set; } = "";
        [StringLength(16, ErrorMessage = "Karakter sayısı 16 aşmamalıdır.")]
        public string sf_vergino { get; set; } = "";
        [RegularExpression(@"^\d+.?\d{0,2}$", ErrorMessage = "Sayı virgülden sonra 2 haneli olmalıdır.")]
        [Range(0, 999.99, ErrorMessage = "Sayı 5 karakterden fazla olamaz.")]
        public decimal sf_total_isk_oran { get; set; } = 0;
        [RegularExpression(@"^\d+.?\d{0,6}$", ErrorMessage = "Sayı virgülden sonra 6 haneli olmalıdır.")]
        [Range(0, 999999999999.999999, ErrorMessage = "Sayı 18 karakterden fazla olamaz.")]
        public decimal sf_total_isk_tutar { get; set; } = 0;
        [RegularExpression(@"^\d+.?\d{0,6}$", ErrorMessage = "Sayı virgülden sonra 6 haneli olmalıdır.")]
        [Range(0, 999999999999.999999, ErrorMessage = "Sayı 18 karakterden fazla olamaz.")]
        public decimal sf_kdv_tutar_tev { get; set; } = 0;
        [Range(-2147483648, 2147483647, ErrorMessage = "Sayı 10 karakterden fazla olamaz.")]
        public int sf_grp_id { get; set; } = 0;
        [StringLength(10, ErrorMessage = "Karakter sayısı 10 aşmamalıdır.")]
        public string sf_grp_kod { get; set; } = "";
        [Range(-2147483648, 2147483647, ErrorMessage = "Sayı 10 karakterden fazla olamaz.")]
        public int sf_ent_id { get; set; } = 0;
        [StringLength(100, ErrorMessage = "Karakter sayısı 100 aşmamalıdır.")]
        public string sf_ent_ad { get; set; } = "";
        [Range(-32768, 32768, ErrorMessage = "Sayı 32768 değeri fazla olamaz.")]
        public int sf_kdv_dh { get; set; } = 0;
        [RegularExpression(@"^\d+.?\d{0,6}$", ErrorMessage = "Sayı virgülden sonra 6 haneli olmalıdır.")]
        [Range(0, 999999999999.999999, ErrorMessage = "Sayı 18 karakterden fazla olamaz.")]
        public decimal sf_isl_tutar { get; set; } = 0;
        [StringLength(5, ErrorMessage = "Karakter sayısı 5 aşmamalıdır.")]
        public string sf_dvz_kod { get; set; } = "";
        [StringLength(5, ErrorMessage = "Karakter sayısı 5 aşmamalıdır.")]
        public string sf_hspdvz_kod { get; set; } = "";
        [Range(-2147483648, 2147483647, ErrorMessage = "Sayı 10 karakterden fazla olamaz.")]
        public int sf_frm_id { get; set; } = 0;
        [Range(-2147483648, 2147483647, ErrorMessage = "Sayı 10 karakterden fazla olamaz.")]
        public int sf_frm_id_2 { get; set; } = 0;
        [StringLength(20, ErrorMessage = "Karakter sayısı 20 aşmamalıdır.")]
        public string sf_frm_kod_2 { get; set; } = "";
        [StringLength(5, ErrorMessage = "Karakter sayısı 5 aşmamalıdır.")]
        public string sf_hspdvz_kod_2 { get; set; } = "";
        [Range(0, 255, ErrorMessage = "Sayı 255 den fazla olamaz.")]
        public int sf_tur { get; set; } = 0;
        [RegularExpression(@"^\d+.?\d{0,10}$", ErrorMessage = "Sayı virgülden sonra 10 haneli olmalıdır.")]
        [Range(0, 99999999.9999999999, ErrorMessage = "Sayı 18 karakterden fazla olamaz.")]
        public decimal sf_hsp_kur { get; set; } = 0;
        [Range(-2147483648, 2147483647, ErrorMessage = "Sayı 10 karakterden fazla olamaz.")]
        public int sf_chsp_mid { get; set; } = 0;
        [Range(-2147483648, 2147483647, ErrorMessage = "Sayı 10 karakterden fazla olamaz.")]
        public int sf_chsp_mid2 { get; set; } = 0;
        [Range(-2147483648, 2147483647, ErrorMessage = "Sayı 10 karakterden fazla olamaz.")]
        public int sf_bhsp_mid { get; set; } = 0;
        [Range(-2147483648, 2147483647, ErrorMessage = "Sayı 10 karakterden fazla olamaz.")]
        public int sf_bhsp_mid2 { get; set; } = 0;
        [Range(-2147483648, 2147483647, ErrorMessage = "Sayı 10 karakterden fazla olamaz.")]
        public int sf_khsp_mid { get; set; } = 0;
        [Range(-2147483648, 2147483647, ErrorMessage = "Sayı 10 karakterden fazla olamaz.")]
        public int sf_khsp_mid2 { get; set; } = 0;
        [StringLength(20, ErrorMessage = "Karakter sayısı 20 aşmamalıdır.")]
        public string sf_efat_no { get; set; } = "";
        [Range(0, 255, ErrorMessage = "Sayı 255 den fazla olamaz.")]
        public int sf_efat_isrt { get; set; } = 0;
        [StringLength(40, ErrorMessage = "Karakter sayısı 40 aşmamalıdır.")]
        public string sf_efat_id { get; set; } = "";
        [RegularExpression(@"^\d+.?\d{0,1}$", ErrorMessage = "Sayı virgülden sonra 1 haneli olmalıdır.")]
        [Range(0, 999.9, ErrorMessage = "Sayı 4 karakterden fazla olamaz.")]
        public decimal sf_tev_oran { get; set; } = 0;
        [Range(-2147483648, 2147483647, ErrorMessage = "Sayı 10 karakterden fazla olamaz.")]
        public int sf_irs_frm_id { get; set; } = 0;
        [StringLength(10, ErrorMessage = "Karakter sayısı 10 aşmamalıdır.")]
        public string sf_ode_plan { get; set; } = "";
        [Range(0, 255, ErrorMessage = "Sayı 255 den fazla olamaz.")]
        public int sf_ode_tip { get; set; } = 0;
        [RegularExpression(@"^\d+.?\d{0,6}$", ErrorMessage = "Sayı virgülden sonra 6 haneli olmalıdır.")]
        [Range(0, 999999999999.999999, ErrorMessage = "Sayı 18 karakterden fazla olamaz.")]
        public decimal sf_ode_tutar { get; set; } = 0;
        [StringLength(10, ErrorMessage = "Karakter sayısı 10 aşmamalıdır.")]
        public string sf_ode_dvz_kod { get; set; } = "";
        [RegularExpression(@"^\d+.?\d{0,6}$", ErrorMessage = "Sayı virgülden sonra 6 haneli olmalıdır.")]
        [Range(0, 999999999999.999999, ErrorMessage = "Sayı 18 karakterden fazla olamaz.")]
        public decimal sf_ode_tutar_fdvz { get; set; } = 0;
        public DateTime? sf_ode_trh { get; set; } = null;
        [RegularExpression(@"^\d+.?\d{0,4}$", ErrorMessage = "Sayı virgülden sonra 4 haneli olmalıdır.")]
        [Range(0, 99999999.9999, ErrorMessage = "Sayı 12 karakterden fazla olamaz.")]
        public decimal sf_ode_kur { get; set; } = 0;
        [Range(-2147483648, 2147483647, ErrorMessage = "Sayı 10 karakterden fazla olamaz.")]
        public int sf_ode_fis_id { get; set; } = 0;
        [Range(0, 255, ErrorMessage = "Sayı 255 den fazla olamaz.")]
        public int sf_odendi { get; set; } = 0;
        [StringLength(100, ErrorMessage = "Karakter sayısı 100 aşmamalıdır.")]
        public string sf_ode_belge { get; set; } = "";
        [Range(-32768, 32768, ErrorMessage = "Sayı 32768 değeri fazla olamaz.")]
        public int sf_hrk_srk { get; set; } = 0;
        [Range(-2147483648, 2147483647, ErrorMessage = "Sayı 10 karakterden fazla olamaz.")]
        public int sf_hrk_tur { get; set; } = 0;
        [Range(-2147483648, 2147483647, ErrorMessage = "Sayı 10 karakterden fazla olamaz.")]
        public int sf_sp_id { get; set; } = 0;
        [Range(-32768, 32768, ErrorMessage = "Sayı 32768 değeri fazla olamaz.")]
        public int sf_sp_no1 { get; set; } = 0;
        [Range(-2147483648, 2147483647, ErrorMessage = "Sayı 10 karakterden fazla olamaz.")]
        public int sf_sp_no2 { get; set; } = 0;
        [StringLength(6, ErrorMessage = "Karakter sayısı 6 aşmamalıdır.")]
        public string sf_ihrc_tip { get; set; } = "";
        [StringLength(20, ErrorMessage = "Karakter sayısı 20 aşmamalıdır.")]
        public string sf_swift_kod { get; set; } = "";
        [RegularExpression(@"^\d+.?\d{0,2}$", ErrorMessage = "Sayı virgülden sonra 2 haneli olmalıdır.")]
        [Range(0, 999999999999.99, ErrorMessage = "Sayı 14 karakterden fazla olamaz.")]
        public decimal sf_parite_tut { get; set; } = 0;
        [RegularExpression(@"^\d+.?\d{0,2}$", ErrorMessage = "Sayı virgülden sonra 2 haneli olmalıdır.")]
        [Range(0, 999999999999.99, ErrorMessage = "Sayı 14 karakterden fazla olamaz.")]
        public decimal sf_fob_tut { get; set; } = 0;
        [RegularExpression(@"^\d+.?\d{0,2}$", ErrorMessage = "Sayı virgülden sonra 2 haneli olmalıdır.")]
        [Range(0, 999999999999.99, ErrorMessage = "Sayı 14 karakterden fazla olamaz.")]
        public decimal sf_nak_tut { get; set; } = 0;
        [RegularExpression(@"^\d+.?\d{0,2}$", ErrorMessage = "Sayı virgülden sonra 2 haneli olmalıdır.")]
        [Range(0, 999999999999.99, ErrorMessage = "Sayı 14 karakterden fazla olamaz.")]
        public decimal sf_sig_tut { get; set; } = 0;
        [Range(-32768, 32768, ErrorMessage = "Sayı 32768 değeri fazla olamaz.")]
        public int sf_sfta_cek_tur { get; set; } = 0;
        [RegularExpression(@"^\d+.?\d{0,4}$", ErrorMessage = "Sayı virgülden sonra 4 haneli olmalıdır.")]
        [Range(0, 99999999999999.9999, ErrorMessage = "Sayı 18 karakterden fazla olamaz.")]
        public decimal sf_isl_tutar_tl { get; set; } = 0;
        [RegularExpression(@"^\d+.?\d{0,4}$", ErrorMessage = "Sayı virgülden sonra 4 haneli olmalıdır.")]
        [Range(0, 99999999999999.9999, ErrorMessage = "Sayı 18 karakterden fazla olamaz.")]
        public decimal sf_isl_tutar_tl_cek_fat { get; set; } = 0;
        [Range(-2147483648, 2147483647, ErrorMessage = "Sayı 10 karakterden fazla olamaz.")]
        public int sf_kdvhsp_mid { get; set; } = 0;
        [Range(-2147483648, 2147483647, ErrorMessage = "Sayı 10 karakterden fazla olamaz.")]
        public int sf_kdvhsp_mid2 { get; set; } = 0;
        [Range(-2147483648, 2147483647, ErrorMessage = "Sayı 10 karakterden fazla olamaz.")]
        public int sf_kdvtev_mid { get; set; } = 0;
        [StringLength(20, ErrorMessage = "Karakter sayısı 20 aşmamalıdır.")]
        public string sf_fat_tip { get; set; } = "";
        [Range(-2147483648, 2147483647, ErrorMessage = "Sayı 10 karakterden fazla olamaz.")]
        public int sf_islt_id { get; set; } = 0;
        [Range(-2147483648, 2147483647, ErrorMessage = "Sayı 10 karakterden fazla olamaz.")]
        public int sf_bol_id { get; set; } = 0;
        [Range(-2147483648, 2147483647, ErrorMessage = "Sayı 10 karakterden fazla olamaz.")]
        public int sf_ei_id { get; set; } = 0;
        [Range(-2147483648, 2147483647, ErrorMessage = "Sayı 10 karakterden fazla olamaz.")]
        public int sf_kdv_istisna { get; set; } = 0;
        [Range(-2147483648, 2147483647, ErrorMessage = "Sayı 10 karakterden fazla olamaz.")]
        public int sf_tev_kismi_is_tur { get; set; } = 0;
        [Range(-2147483648, 2147483647, ErrorMessage = "Sayı 10 karakterden fazla olamaz.")]
        public int sf_tev_ode_tur { get; set; } = 0;
        [RegularExpression(@"^\d+.?\d{0,4}$", ErrorMessage = "Sayı virgülden sonra 4 haneli olmalıdır.")]
        [Range(0, 99999999999999.9999, ErrorMessage = "Sayı 18 karakterden fazla olamaz.")]
        public decimal sf_kabul_tutar { get; set; } = 0;
        [RegularExpression(@"^\d+.?\d{0,3}$", ErrorMessage = "Sayı virgülden sonra 3 haneli olmalıdır.")]
        [Range(0, 99999.999, ErrorMessage = "Sayı 8 karakterden fazla olamaz.")]
        public decimal sf_stopaj_oran { get; set; } = 0;
        [Range(-2147483648, 2147483647, ErrorMessage = "Sayı 10 karakterden fazla olamaz.")]
        public int sf_stopaj_mid { get; set; } = 0;
        [RegularExpression(@"^\d+.?\d{0,4}$", ErrorMessage = "Sayı virgülden sonra 4 haneli olmalıdır.")]
        [Range(0, 99999999999999.9999, ErrorMessage = "Sayı 18 karakterden fazla olamaz.")]
        public decimal sf_stopaj_tutar { get; set; } = 0;
        [Range(-2147483648, 2147483647, ErrorMessage = "Sayı 10 karakterden fazla olamaz.")]
        public int sf_kur_fark_bmid { get; set; } = 0;
        [Range(-2147483648, 2147483647, ErrorMessage = "Sayı 10 karakterden fazla olamaz.")]
        public int sf_kur_fark_amid { get; set; } = 0;
        [RegularExpression(@"^\d+.?\d{0,2}$", ErrorMessage = "Sayı virgülden sonra 2 haneli olmalıdır.")]
        [Range(0, 999999999999.99, ErrorMessage = "Sayı 14 karakterden fazla olamaz.")]
        public decimal sf_kur_fark_tutar_a { get; set; } = 0;
        [RegularExpression(@"^\d+.?\d{0,2}$", ErrorMessage = "Sayı virgülden sonra 2 haneli olmalıdır.")]
        [Range(0, 999999999999.99, ErrorMessage = "Sayı 14 karakterden fazla olamaz.")]
        public decimal sf_kur_fark_tutar_b { get; set; } = 0;
        [StringLength(70, ErrorMessage = "Karakter sayısı 70 aşmamalıdır.")]
        public string sf_beyanname { get; set; } = "";
        [Range(-2147483648, 2147483647, ErrorMessage = "Sayı 10 karakterden fazla olamaz.")]
        public int sf_gumruk_id { get; set; } = 0;
        [StringLength(70, ErrorMessage = "Karakter sayısı 70 aşmamalıdır.")]
        public string sf_beyanname2 { get; set; } = "";
        [RegularExpression(@"^\d+.?\d{0,4}$", ErrorMessage = "Sayı virgülden sonra 4 haneli olmalıdır.")]
        [Range(0, 9999999999.9999, ErrorMessage = "Sayı 14 karakterden fazla olamaz.")]
        public decimal sf_damga_vergisi { get; set; } = 0;
        [StringLength(100, ErrorMessage = "Karakter sayısı 100 aşmamalıdır.")]
        public string sf_acenta { get; set; } = "";
        [RegularExpression(@"^\d+.?\d{0,4}$", ErrorMessage = "Sayı virgülden sonra 4 haneli olmalıdır.")]
        [Range(0, 9999999999.9999, ErrorMessage = "Sayı 14 karakterden fazla olamaz.")]
        public decimal sf_gumruk_vergisi { get; set; } = 0;
        [RegularExpression(@"^\d+.?\d{0,4}$", ErrorMessage = "Sayı virgülden sonra 4 haneli olmalıdır.")]
        [Range(0, 9999999999.9999, ErrorMessage = "Sayı 14 karakterden fazla olamaz.")]
        public decimal sf_ilave_gumruk_vergisi { get; set; } = 0;
        [RegularExpression(@"^\d+.?\d{0,4}$", ErrorMessage = "Sayı virgülden sonra 4 haneli olmalıdır.")]
        [Range(0, 9999999999.9999, ErrorMessage = "Sayı 14 karakterden fazla olamaz.")]
        public decimal sf_anti_damping_vergisi { get; set; } = 0;
        [RegularExpression(@"^\d+.?\d{0,4}$", ErrorMessage = "Sayı virgülden sonra 4 haneli olmalıdır.")]
        [Range(0, 9999999999.9999, ErrorMessage = "Sayı 14 karakterden fazla olamaz.")]
        public decimal sf_otv { get; set; } = 0;
        [RegularExpression(@"^\d+.?\d{0,4}$", ErrorMessage = "Sayı virgülden sonra 4 haneli olmalıdır.")]
        [Range(0, 9999999999.9999, ErrorMessage = "Sayı 14 karakterden fazla olamaz.")]
        public decimal sf_kdv { get; set; } = 0;
        [RegularExpression(@"^\d+.?\d{0,4}$", ErrorMessage = "Sayı virgülden sonra 4 haneli olmalıdır.")]
        [Range(0, 99999999999999.9999, ErrorMessage = "Sayı 18 karakterden fazla olamaz.")]
        public decimal sf_anti_damping_tutar { get; set; } = 0;
        public DateTime? sf_freetime_trh { get; set; } = null;
        [RegularExpression(@"^\d+.?\d{0,4}$", ErrorMessage = "Sayı virgülden sonra 4 haneli olmalıdır.")]
        [Range(0, 9999999999.9999, ErrorMessage = "Sayı 14 karakterden fazla olamaz.")]
        public decimal sf_navlun_tutar { get; set; } = 0;
        [RegularExpression(@"^\d+.?\d{0,4}$", ErrorMessage = "Sayı virgülden sonra 4 haneli olmalıdır.")]
        [Range(0, 9999999999.9999, ErrorMessage = "Sayı 14 karakterden fazla olamaz.")]
        public decimal sf_iht_sigorta_tutar { get; set; } = 0;
        [Range(-32768, 32768, ErrorMessage = "Sayı 32768 değeri fazla olamaz.")]
        public int sf_spd_sira { get; set; } = 0;
        [Range(-2147483648, 2147483647, ErrorMessage = "Sayı 10 karakterden fazla olamaz.")]
        public int sf_spd_primno { get; set; } = 0;
        [Range(-2147483648, 2147483647, ErrorMessage = "Sayı 10 karakterden fazla olamaz.")]
        public int sf_spd_id { get; set; } = 0;
        [StringLength(20, ErrorMessage = "Karakter sayısı 20 aşmamalıdır.")]
        public string sf_kur_tur { get; set; } = "";
        [RegularExpression(@"^\d+.?\d{0,1}$", ErrorMessage = "Sayı virgülden sonra 1 haneli olmalıdır.")]
        [Range(0, 999.9, ErrorMessage = "Sayı 4 karakterden fazla olamaz.")]
        public decimal sf_otv_oran { get; set; } = 0;
        [RegularExpression(@"^\d+.?\d{0,1}$", ErrorMessage = "Sayı virgülden sonra 1 haneli olmalıdır.")]
        [Range(0, 999.9, ErrorMessage = "Sayı 4 karakterden fazla olamaz.")]
        public decimal sf_ekvergi1_oran { get; set; } = 0;
        [RegularExpression(@"^\d+.?\d{0,1}$", ErrorMessage = "Sayı virgülden sonra 1 haneli olmalıdır.")]
        [Range(0, 999.9, ErrorMessage = "Sayı 4 karakterden fazla olamaz.")]
        public decimal sf_ekvergi2_oran { get; set; } = 0;
        [RegularExpression(@"^\d+.?\d{0,4}$", ErrorMessage = "Sayı virgülden sonra 4 haneli olmalıdır.")]
        [Range(0, 99999999999999.9999, ErrorMessage = "Sayı 18 karakterden fazla olamaz.")]
        public decimal sf_otv_tutar { get; set; } = 0;
        [RegularExpression(@"^\d+.?\d{0,4}$", ErrorMessage = "Sayı virgülden sonra 4 haneli olmalıdır.")]
        [Range(0, 99999999999999.9999, ErrorMessage = "Sayı 18 karakterden fazla olamaz.")]
        public decimal sf_ekvergi1_tutar { get; set; } = 0;
        [RegularExpression(@"^\d+.?\d{0,4}$", ErrorMessage = "Sayı virgülden sonra 4 haneli olmalıdır.")]
        [Range(0, 99999999999999.9999, ErrorMessage = "Sayı 18 karakterden fazla olamaz.")]
        public decimal sf_ekvergi2_tutar { get; set; } = 0;
        public DateTime? sf_ipt_trh { get; set; } = null;
        [RegularExpression(@"^\d+.?\d{0,4}$", ErrorMessage = "Sayı virgülden sonra 4 haneli olmalıdır.")]
        [Range(0, 99999999999999.9999, ErrorMessage = "Sayı 18 karakterden fazla olamaz.")]
        public decimal sf_nak_tutar { get; set; } = 0;
        [RegularExpression(@"^\d+.?\d{0,4}$", ErrorMessage = "Sayı virgülden sonra 4 haneli olmalıdır.")]
        [Range(0, 99999999999999.9999, ErrorMessage = "Sayı 18 karakterden fazla olamaz.")]
        public decimal sf_det_tutar_tl { get; set; } = 0;
        [StringLength(20, ErrorMessage = "Karakter sayısı 20 aşmamalıdır.")]
        public string sf_eirs_no { get; set; } = "";
        [Range(0, 255, ErrorMessage = "Sayı 255 den fazla olamaz.")]
        public int sf_eirs_isrt { get; set; } = 0;
        [StringLength(40, ErrorMessage = "Karakter sayısı 40 aşmamalıdır.")]
        public string sf_eirs_id { get; set; } = "";
        [StringLength(50, ErrorMessage = "Karakter sayısı 50 aşmamalıdır.")]
        public string sf_ent_guid { get; set; } = "";
        [Range(-2147483648, 2147483647, ErrorMessage = "Sayı 10 karakterden fazla olamaz.")]
        public int sf_kr_id { get; set; } = 0;
        [Range(-2147483648, 2147483647, ErrorMessage = "Sayı 10 karakterden fazla olamaz.")]
        public int sf_krdt_id { get; set; } = 0;
        [StringLength(100, ErrorMessage = "Karakter sayısı 100 aşmamalıdır.")]
        public string sf_ozel_kod1 { get; set; } = "";
        [StringLength(100, ErrorMessage = "Karakter sayısı 100 aşmamalıdır.")]
        public string sf_ozel_kod2 { get; set; } = "";
        [StringLength(100, ErrorMessage = "Karakter sayısı 100 aşmamalıdır.")]
        public string sf_ozel_kod3 { get; set; } = "";
        [StringLength(10, ErrorMessage = "Karakter sayısı 10 aşmamalıdır.")]
        public string sf_tev_kod { get; set; } = "";
        [Range(-2147483648, 2147483647, ErrorMessage = "Sayı 10 karakterden fazla olamaz.")]
        public int sf_eirs_sw { get; set; } = 0;
        [StringLength(20, ErrorMessage = "Karakter sayısı 20 aşmamalıdır.")]
        public string sf_eirs_ynt_no { get; set; } = "";
        [StringLength(50, ErrorMessage = "Karakter sayısı 50 aşmamalıdır.")]
        public string sf_eirs_ynt_guid { get; set; } = "";
        [StringLength(50, ErrorMessage = "Karakter sayısı 50 aşmamalıdır.")]
        public string sf_win_adi { get; set; } = "";
        public DateTime? sf_intouch_trh { get; set; } = null;
        [Range(-2147483648, 2147483647, ErrorMessage = "Sayı 10 karakterden fazla olamaz.")]
        public int sf_kdvtev_mid2 { get; set; } = 0;
        [RegularExpression(@"^\d+.?\d{0,4}$", ErrorMessage = "Sayı virgülden sonra 4 haneli olmalıdır.")]
        [Range(0, 99999999999999.9999, ErrorMessage = "Sayı 18 karakterden fazla olamaz.")]
        public decimal sf_det_kdvtutar_tl { get; set; } = 0;
        [Range(-32768, 32768, ErrorMessage = "Sayı 32768 değeri fazla olamaz.")]
        public int sf_fis_sira { get; set; } = 0;

        public Object? Where { get; set; }

    }

    public class StkfCmpt
    {
        public string cmpt_mm_ad { get; set; } = "";
        public decimal cmpt_sf_isl_tutar { get; set; }
        public int cmpt_previous_sf_primno { get; set; }
        public int cmpt_sf_primno { get; set; }
    }

}
