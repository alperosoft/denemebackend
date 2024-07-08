using AutoMapper;
using Osoft.SiparisOnay.Core.DTO;
using Osoft.SiparisOnay.Core.Models;

namespace Osoft.SiparisOnay.Api.Mapping
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<Spd, SpdDTO>().ReverseMap();
            CreateMap<Mamlz, MamlzDTO>().ReverseMap();
            CreateMap<Mamlz, MamlzFilterDTO>().ReverseMap();
            CreateMap<Mamlz, MamlzYardimDTO>().ForMember(dest => dest.cmpt_grp, opt => opt.MapFrom(src => src.mamlzYardimCmpt.cmpt_grp))
                                              .ForMember(dest => dest.cmpt_rct, opt => opt.MapFrom(src => src.mamlzYardimCmpt.cmpt_rct))
                                              .ForMember(dest => dest.cmpt_ipno, opt => opt.MapFrom(src => src.mamlzYardimCmpt.cmpt_ipno)).ReverseMap();
            CreateMap<Personel, PersonelDTO>().ReverseMap();
            CreateMap<Spkateg, SpkategDTO>().ReverseMap();
            CreateMap<Gnstr, GnstrDTO>().ReverseMap();
            CreateMap<Lb, LbDTO>().ReverseMap();
            CreateMap<Firma, FirmaDTO>()
                .ForMember(dest => dest.frmg_ad, opt => opt.MapFrom(src => src.firmagrp.frmg_ad))
                .ReverseMap();
            CreateMap<FirmaDist, FirmaDistDTO>().ReverseMap();
            CreateMap<Firmadr, FirmadrDTO>().ReverseMap();
            CreateMap<Sp, SpDTO>().ReverseMap();
            CreateMap<Colors, ColorsDTO>().ReverseMap();
            CreateMap<Ambalaj, AmbalajDTO>().ReverseMap();
            CreateMap<Ebat, EbatDTO>().ReverseMap();
            CreateMap<Doviz, DovizDTO>().ReverseMap();
            CreateMap<Birim, BirimDTO>().ReverseMap();
            CreateMap<Fyttur, FytturDTO>().ReverseMap();
            CreateMap<Spgrp, SpgrpDTO>().ReverseMap();
            CreateMap<Isletme, IsletmeDTO>().ReverseMap();
            CreateMap<TableId, TableIdDTO>().ReverseMap();
            CreateMap<Lfyd, LfydDTO>()
                .ForMember(dest => dest.mm_ad, opt => opt.MapFrom(src => src.Mamlz != null ? src.Mamlz.mm_ad : null))
                .ForMember(dest => dest.cl_ad, opt => opt.MapFrom(src => src.Colors != null ? src.Colors.cl_ad : null))
                .ForMember(dest => dest.frm_ksad, opt => opt.MapFrom(src => src.Firma != null ? src.Firma.frm_ksad : null)).ReverseMap();
            CreateMap<Spd, SpdFiltreDTO>()
                .ForMember(dest => dest.mm_ad, opt => opt.MapFrom(src => src.mamlz != null ? src.mamlz.mm_ad : null))
                .ForMember(dest => dest.mm_alis_fiyat, opt => opt.MapFrom(src => src.mamlz != null ? src.mamlz.mm_alis_fiyat : (decimal?)null))
                .ForMember(dest => dest.mm_alis_dvz_kod, opt => opt.MapFrom(src => src.mamlz != null ? src.mamlz.mm_alis_dvz_kod : null))
                .ForMember(dest => dest.sp_siptrh, opt => opt.MapFrom(src => src.sp != null ? src.sp.sp_siptrh : null))
                .ForMember(dest => dest.frm_ksad, opt => opt.MapFrom(src => src.firma != null ? src.firma.frm_ksad : null)).ReverseMap();

            CreateMap<Stkfd, StkfdSatisUrunDTO>()
                 .ForMember(dest => dest.dp_ad, opt => opt.MapFrom(src => src.depo != null ? src.depo.dp_ad : null))
                .ForMember(dest => dest.fist_tanim, opt => opt.MapFrom(src => src.fistip != null ? src.fistip.fist_tanim : null))
                .ForMember(dest => dest.grp_kod, opt => opt.MapFrom(src => src.grup != null ? src.grup.grp_kod : null))
                .ForMember(dest => dest.grp_ad, opt => opt.MapFrom(src => src.grup != null ? src.grup.grp_ad : null));
         

            CreateMap<Spurt, SpurtOrguUretimDTO>()
                .ForMember(dest => dest.grp_ad, opt => opt.MapFrom(src => src.grup != null ? src.grup.grp_ad : null))
                .ForMember(dest => dest.grp_kod, opt => opt.MapFrom(src => src.grup != null ? src.grup.grp_kod : null))
                .ForMember(dest => dest.cmpt_umkt_kg, opt => opt.MapFrom(src => src.spurtCmpt != null ? src.spurtCmpt.cmpt_umkt_kg : (decimal?)null))
                .ForMember(dest => dest.cmpt_ubmkt_kg, opt => opt.MapFrom(src => src.spurtCmpt != null ? src.spurtCmpt.cmpt_ubmkt_kg : (decimal?)null))
                .ForMember(dest => dest.cmpt_umkt_kg, opt => opt.MapFrom(src => src.spurtCmpt != null ? src.spurtCmpt.cmpt_umkt_kg : (decimal?)null)).ReverseMap();
            CreateMap<Recete, ReceteDTO>()
                .ForMember(dest => dest.rtgr_kod, opt => opt.MapFrom(src => src.receteGrp != null ? src.receteGrp.rtgr_kod : null))
                .ForMember(dest => dest.rtgr_ad, opt => opt.MapFrom(src => src.receteGrp != null ? src.receteGrp.rtgr_ad : null))
                .ForMember(dest => dest.rtgr_kod, opt => opt.MapFrom(src => src.receteGrp != null ? src.receteGrp.rtgr_kod : null))
                .ForMember(dest => dest.cmpt_bakiye_kg, opt => opt.MapFrom(src => src.receteCmpt != null ? src.receteCmpt.cmpt_bakiye_kg : (decimal?)null))
                .ForMember(dest => dest.cmpt_bakiye_mt, opt => opt.MapFrom(src => src.receteCmpt != null ? src.receteCmpt.cmpt_bakiye_mt : (decimal?)null)).ReverseMap();

            CreateMap<Spwo, SpwoUretimDTO>().ReverseMap();

            CreateMap<Colors, GelenRenkDTO>()
                .ForMember(dest => dest.frm_ksad, opt => opt.MapFrom(src => src.firma != null ? src.firma.frm_ksad : null))
                .ForMember(dest => dest.cmpt_gelen_renk_say, opt => opt.MapFrom(src => src.colorsCmpt != null ? src.colorsCmpt.cmpt_gelen_renk_say : (int?)null)).ReverseMap();
            CreateMap<Colors, OnayRenkDTO>()
                .ForMember(dest => dest.frm_ksad, opt => opt.MapFrom(src => src.firma != null ? src.firma.frm_ksad : null))
                .ForMember(dest => dest.cmpt_onay_renk_say, opt => opt.MapFrom(src => src.colorsCmpt != null ? src.colorsCmpt.cmpt_onay_renk_say : (int?)null)).ReverseMap();


        }
    }
}