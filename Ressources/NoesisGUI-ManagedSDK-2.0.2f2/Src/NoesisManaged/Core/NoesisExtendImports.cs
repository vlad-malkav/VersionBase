using System;
using System.Runtime.InteropServices;

namespace Noesis
{
    internal partial class Extend
    {
        private static IntPtr Noesis_RegisterEnumType_(string typeName,
            int numEnums, IntPtr enumsData)
        {
            IntPtr result = Noesis_RegisterEnumType(typeName, numEnums, enumsData);
            Error.Check();
            return result;
        }

        private static void Noesis_FillExtendType_(ref ExtendTypeData typeData,
            int numProps, IntPtr propsData)
        {
            Noesis_FillExtendType(ref typeData, numProps, propsData);
            Error.Check();
        }

        private static IntPtr Noesis_InstantiateExtend_(IntPtr nativeType)
        {
            IntPtr result = Noesis_InstantiateExtend(nativeType);
            Error.Check();
            return result;
        }

        private static void Noesis_LaunchPropertyChangedEvent_(IntPtr nativeType, IntPtr cPtr, string propertyName)
        {
            Noesis_LaunchPropertyChangedEvent(nativeType, cPtr, propertyName);
            Error.Check();
        }

        private static void Noesis_LaunchCollectionChangedEvent_(IntPtr nativeType, IntPtr cPtr, int action,
            IntPtr newItem, IntPtr oldItem, int newIndex, int oldIndex)
        {
            Noesis_LaunchCollectionChangedEvent(nativeType, cPtr, action, newItem, oldItem, newIndex, oldIndex);
            Error.Check();
        }

        private static IntPtr Noesis_GetResourceKeyType_(IntPtr nativeType)
        {
            IntPtr result = Noesis_GetResourceKeyType(nativeType);
            Error.Check();
            return result;
        }

        private static void Noesis_EnableExtend_(bool enable)
        {
            Noesis_EnableExtend(enable);
            Error.Check();
        }

        private static void Noesis_ClearExtendTypes_()
        {
            Noesis_ClearExtendTypes();
            Error.Check();
        }

        private static void Noesis_RegisterReflectionCallbacks_(
            Callback_FreeString callback_FreeString,
            Callback_RegisterType callback_RegisterType,
            Callback_DependencyPropertyChanged callback_DependencyPropertyChanged,
            Callback_OnPostInit callback_OnPostInit,
            Callback_FrameworkElementConnect callback_FrameworkElementConnect,
            Callback_ToString callback_ToString,
            Callback_Equals callback_Equals,
            Callback_GetHashCode callback_GetHashCode,
            Callback_CommandCanExecute callback_CommandCanExecute,
            Callback_CommandExecute callback_CommandExecute,
            Callback_ConverterConvert callback_ConverterConvert,
            Callback_ConverterConvertBack callback_ConverterConvertBack,
            Callback_ListCount callback_ListCount,
            Callback_ListGet callback_ListGet,
            Callback_ListSet callback_ListSet,
            Callback_ListAdd callback_ListAdd,
            Callback_ListClear callback_ListClear,
            Callback_ListContains callback_ListContains,
            Callback_ListIndexOf callback_ListIndexOf,
            Callback_ListInsert callback_ListInsert,
            Callback_ListRemove callback_ListRemove,
            Callback_ListRemoveAt callback_ListRemoveAt,
            Callback_DictionaryCount callback_DictionaryCount,
            Callback_DictionaryContains callback_DictionaryContains,
            Callback_DictionaryFind callback_DictionaryFind,
            Callback_DictionarySet callback_DictionarySet,
            Callback_DictionaryAdd callback_DictionaryAdd,
            Callback_DictionaryRemove callback_DictionaryRemove,
            Callback_DictionaryClear callback_DictionaryClear,
            Callback_DictionaryGetKey callback_DictionaryGetKey,
            Callback_ListIndexerTryGet callback_ListIndexerTryGet,
            Callback_ListIndexerTrySet callback_ListIndexerTrySet,
            Callback_DictionaryIndexerTryGet callback_DictionaryIndexerTryGet,
            Callback_DictionaryIndexerTrySet callback_DictionaryIndexerTrySet,
            Callback_SelectTemplate callback_SelectTemplate,
            Callback_StreamSetPosition callback_StreamSetPosition,
            Callback_StreamGetPosition callback_StreamGetPosition,
            Callback_StreamGetLength callback_StreamGetLength,
            Callback_StreamRead callback_StreamRead,
            Callback_ProviderLoadXaml callback_ProviderLoadXaml,
            Callback_ProviderTextureInfo callback_ProviderTextureInfo,
            Callback_ProviderTextureLoad callback_ProviderTextureLoad,
            Callback_ProviderScanFolder callback_ProviderScanFolder,
            Callback_ProviderOpenFont callback_ProviderOpenFont,
            Callback_GetPropertyInfo callback_GetPropertyInfo,
            Callback_GetPropertyValue_Bool callback_GetPropertyValue_Bool,
            Callback_GetPropertyValue_Float callback_GetPropertyValue_Float,
            Callback_GetPropertyValue_Double callback_GetPropertyValue_Double,
            Callback_GetPropertyValue_Int callback_GetPropertyValue_Int,
            Callback_GetPropertyValue_UInt callback_GetPropertyValue_UInt,
            Callback_GetPropertyValue_Short callback_GetPropertyValue_Short,
            Callback_GetPropertyValue_UShort callback_GetPropertyValue_UShort,
            Callback_GetPropertyValue_String callback_GetPropertyValue_String,
            Callback_GetPropertyValue_Color callback_GetPropertyValue_Color,
            Callback_GetPropertyValue_Point callback_GetPropertyValue_Point,
            Callback_GetPropertyValue_Rect callback_GetPropertyValue_Rect,
            Callback_GetPropertyValue_Size callback_GetPropertyValue_Size,
            Callback_GetPropertyValue_Thickness callback_GetPropertyValue_Thickness,
            Callback_GetPropertyValue_CornerRadius callback_GetPropertyValue_CornerRadius,
            Callback_GetPropertyValue_TimeSpan callback_GetPropertyValue_TimeSpan,
            Callback_GetPropertyValue_Duration callback_GetPropertyValue_Duration,
            Callback_GetPropertyValue_KeyTime callback_GetPropertyValue_KeyTime,
            Callback_GetPropertyValue_BaseComponent callback_GetPropertyValue_BaseComponent,
            Callback_SetPropertyValue_Bool callback_SetPropertyValue_Bool,
            Callback_SetPropertyValue_Float callback_SetPropertyValue_Float,
            Callback_SetPropertyValue_Double callback_SetPropertyValue_Double,
            Callback_SetPropertyValue_Int callback_SetPropertyValue_Int,
            Callback_SetPropertyValue_UInt callback_SetPropertyValue_UInt,
            Callback_SetPropertyValue_Short callback_SetPropertyValue_Short,
            Callback_SetPropertyValue_UShort callback_SetPropertyValue_UShort,
            Callback_SetPropertyValue_String callback_SetPropertyValue_String,
            Callback_SetPropertyValue_Color callback_SetPropertyValue_Color,
            Callback_SetPropertyValue_Point callback_SetPropertyValue_Point,
            Callback_SetPropertyValue_Rect callback_SetPropertyValue_Rect,
            Callback_SetPropertyValue_Size callback_SetPropertyValue_Size,
            Callback_SetPropertyValue_Thickness callback_SetPropertyValue_Thickness,
            Callback_SetPropertyValue_CornerRadius callback_SetPropertyValue_CornerRadius,
            Callback_SetPropertyValue_TimeSpan callback_SetPropertyValue_TimeSpan,
            Callback_SetPropertyValue_Duration callback_SetPropertyValue_Duration,
            Callback_SetPropertyValue_KeyTime callback_SetPropertyValue_KeyTime,
            Callback_SetPropertyValue_BaseComponent callback_SetPropertyValue_BaseComponent,
            Callback_CreateInstance callback_CreateInstance,
            Callback_DeleteInstance callback_DeleteInstance,
            Callback_GrabInstance callback_GrabInstance)
        {
            Noesis_RegisterReflectionCallbacks(
                callback_FreeString,
                callback_RegisterType,
                callback_DependencyPropertyChanged,
                callback_OnPostInit,
                callback_FrameworkElementConnect,
                callback_ToString,
                callback_Equals,
                callback_GetHashCode,
                callback_CommandCanExecute,
                callback_CommandExecute,
                callback_ConverterConvert,
                callback_ConverterConvertBack,
                callback_ListCount,
                callback_ListGet,
                callback_ListSet,
                callback_ListAdd,
                callback_ListClear,
                callback_ListContains,
                callback_ListIndexOf,
                callback_ListInsert,
                callback_ListRemove,
                callback_ListRemoveAt,
                callback_DictionaryCount,
                callback_DictionaryContains,
                callback_DictionaryFind,
                callback_DictionarySet,
                callback_DictionaryAdd,
                callback_DictionaryRemove,
                callback_DictionaryClear,
                callback_DictionaryGetKey,
                callback_ListIndexerTryGet,
                callback_ListIndexerTrySet,
                callback_DictionaryIndexerTryGet,
                callback_DictionaryIndexerTrySet,
                callback_SelectTemplate,
                callback_StreamSetPosition,
                callback_StreamGetPosition,
                callback_StreamGetLength,
                callback_StreamRead,
                callback_ProviderLoadXaml,
                callback_ProviderTextureInfo,
                callback_ProviderTextureLoad,
                callback_ProviderScanFolder,
                callback_ProviderOpenFont,
                callback_GetPropertyInfo,
                callback_GetPropertyValue_Bool,
                callback_GetPropertyValue_Float,
                callback_GetPropertyValue_Double,
                callback_GetPropertyValue_Int,
                callback_GetPropertyValue_UInt,
                callback_GetPropertyValue_Short,
                callback_GetPropertyValue_UShort,
                callback_GetPropertyValue_String,
                callback_GetPropertyValue_Color,
                callback_GetPropertyValue_Point,
                callback_GetPropertyValue_Rect,
                callback_GetPropertyValue_Size,
                callback_GetPropertyValue_Thickness,
                callback_GetPropertyValue_CornerRadius,
                callback_GetPropertyValue_TimeSpan,
                callback_GetPropertyValue_Duration,
                callback_GetPropertyValue_KeyTime,
                callback_GetPropertyValue_BaseComponent,
                callback_SetPropertyValue_Bool,
                callback_SetPropertyValue_Float,
                callback_SetPropertyValue_Double,
                callback_SetPropertyValue_Int,
                callback_SetPropertyValue_UInt,
                callback_SetPropertyValue_Short,
                callback_SetPropertyValue_UShort,
                callback_SetPropertyValue_String,
                callback_SetPropertyValue_Color,
                callback_SetPropertyValue_Point,
                callback_SetPropertyValue_Rect,
                callback_SetPropertyValue_Size,
                callback_SetPropertyValue_Thickness,
                callback_SetPropertyValue_CornerRadius,
                callback_SetPropertyValue_TimeSpan,
                callback_SetPropertyValue_Duration,
                callback_SetPropertyValue_KeyTime,
                callback_SetPropertyValue_BaseComponent,
                callback_CreateInstance,
                callback_DeleteInstance,
                callback_GrabInstance);
            Error.Check();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////
        [DllImport(Library.Name)]
        private static extern IntPtr Noesis_RegisterEnumType([MarshalAs(UnmanagedType.LPStr)]string typeName,
            int numEnums, IntPtr enumsData);

        ////////////////////////////////////////////////////////////////////////////////////////////////
        [DllImport(Library.Name)]
        private static extern void Noesis_FillExtendType(ref ExtendTypeData typeData,
            int numProps, IntPtr propsData);

        ////////////////////////////////////////////////////////////////////////////////////////////////
        [DllImport(Library.Name)]
        private static extern IntPtr Noesis_InstantiateExtend(IntPtr nativeType);

        ////////////////////////////////////////////////////////////////////////////////////////////////
        [DllImport(Library.Name)]
        private static extern void Noesis_LaunchPropertyChangedEvent(IntPtr nativeType, IntPtr cPtr,
            [MarshalAs(UnmanagedType.LPStr)]string propertyName);

        ////////////////////////////////////////////////////////////////////////////////////////////////
        [DllImport(Library.Name)]
        private static extern void Noesis_LaunchCollectionChangedEvent(IntPtr nativeType, IntPtr cPtr,
            int action, IntPtr newItem, IntPtr oldItem, int newIndex, int oldIndex);

        ////////////////////////////////////////////////////////////////////////////////////////////////
        [DllImport(Library.Name)]
        private static extern IntPtr Noesis_GetResourceKeyType(IntPtr nativeType);

        ////////////////////////////////////////////////////////////////////////////////////////////////
        [DllImport(Library.Name)]
        private static extern void Noesis_EnableExtend(bool enable);

        ////////////////////////////////////////////////////////////////////////////////////////////////
        [DllImport(Library.Name)]
        private static extern void Noesis_ClearExtendTypes();

        ////////////////////////////////////////////////////////////////////////////////////////////////
        [DllImport(Library.Name)]
        static extern void Noesis_RegisterReflectionCallbacks(
            Callback_FreeString callback_FreeString,
            Callback_RegisterType callback_RegisterType,
            Callback_DependencyPropertyChanged callback_DependencyPropertyChanged,
            Callback_OnPostInit callback_OnPostInit,
            Callback_FrameworkElementConnect callback_FrameworkElementConnect,
            Callback_ToString callback_ToString,
            Callback_Equals callback_Equals,
            Callback_GetHashCode callback_GetHashCode,
            Callback_CommandCanExecute callback_CommandCanExecute,
            Callback_CommandExecute callback_CommandExecute,
            Callback_ConverterConvert callback_ConverterConvert,
            Callback_ConverterConvertBack callback_ConverterConvertBack,
            Callback_ListCount callback_ListCount,
            Callback_ListGet callback_ListGet,
            Callback_ListSet callback_ListSet,
            Callback_ListAdd callback_ListAdd,
            Callback_ListClear callback_ListClear,
            Callback_ListContains callback_ListContains,
            Callback_ListIndexOf callback_ListIndexOf,
            Callback_ListInsert callback_ListInsert,
            Callback_ListRemove callback_ListRemove,
            Callback_ListRemoveAt callback_ListRemoveAt,
            Callback_DictionaryCount callback_DictionaryCount,
            Callback_DictionaryContains callback_DictionaryContains,
            Callback_DictionaryFind callback_DictionaryFind,
            Callback_DictionarySet callback_DictionarySet,
            Callback_DictionaryAdd callback_DictionaryAdd,
            Callback_DictionaryRemove callback_DictionaryRemove,
            Callback_DictionaryClear callback_DictionaryClear,
            Callback_DictionaryGetKey callback_DictionaryGetKey,
            Callback_ListIndexerTryGet callback_ListIndexerTryGet,
            Callback_ListIndexerTrySet callback_ListIndexerTrySet,
            Callback_DictionaryIndexerTryGet callback_DictionaryIndexerTryGet,
            Callback_DictionaryIndexerTrySet callback_DictionaryIndexerTrySet,
            Callback_SelectTemplate callback_SelectTemplate,
            Callback_StreamSetPosition callback_StreamSetPosition,
            Callback_StreamGetPosition callback_StreamGetPosition,
            Callback_StreamGetLength callback_StreamGetLength,
            Callback_StreamRead callback_StreamRead,
            Callback_ProviderLoadXaml callback_ProviderLoadXaml,
            Callback_ProviderTextureInfo callback_ProviderTextureInfo,
            Callback_ProviderTextureLoad callback_ProviderTextureLoad,
            Callback_ProviderScanFolder callback_ProviderScanFolder,
            Callback_ProviderOpenFont callback_ProviderOpenFont,
            Callback_GetPropertyInfo callback_GetPropertyInfo,
            Callback_GetPropertyValue_Bool callback_GetPropertyValue_Bool,
            Callback_GetPropertyValue_Float callback_GetPropertyValue_Float,
            Callback_GetPropertyValue_Double callback_GetPropertyValue_Double,
            Callback_GetPropertyValue_Int callback_GetPropertyValue_Int,
            Callback_GetPropertyValue_UInt callback_GetPropertyValue_UInt,
            Callback_GetPropertyValue_Short callback_GetPropertyValue_Short,
            Callback_GetPropertyValue_UShort callback_GetPropertyValue_UShort,
            Callback_GetPropertyValue_String callback_GetPropertyValue_String,
            Callback_GetPropertyValue_Color callback_GetPropertyValue_Color,
            Callback_GetPropertyValue_Point callback_GetPropertyValue_Point,
            Callback_GetPropertyValue_Rect callback_GetPropertyValue_Rect,
            Callback_GetPropertyValue_Size callback_GetPropertyValue_Size,
            Callback_GetPropertyValue_Thickness callback_GetPropertyValue_Thickness,
            Callback_GetPropertyValue_CornerRadius callback_GetPropertyValue_CornerRadius,
            Callback_GetPropertyValue_TimeSpan callback_GetPropertyValue_TimeSpan,
            Callback_GetPropertyValue_Duration callback_GetPropertyValue_Duration,
            Callback_GetPropertyValue_KeyTime callback_GetPropertyValue_KeyTime,
            Callback_GetPropertyValue_BaseComponent callback_GetPropertyValue_BaseComponent,
            Callback_SetPropertyValue_Bool callback_SetPropertyValue_Bool,
            Callback_SetPropertyValue_Float callback_SetPropertyValue_Float,
            Callback_SetPropertyValue_Double callback_SetPropertyValue_Double,
            Callback_SetPropertyValue_Int callback_SetPropertyValue_Int,
            Callback_SetPropertyValue_UInt callback_SetPropertyValue_UInt,
            Callback_SetPropertyValue_Short callback_SetPropertyValue_Short,
            Callback_SetPropertyValue_UShort callback_SetPropertyValue_UShort,
            Callback_SetPropertyValue_String callback_SetPropertyValue_String,
            Callback_SetPropertyValue_Color callback_SetPropertyValue_Color,
            Callback_SetPropertyValue_Point callback_SetPropertyValue_Point,
            Callback_SetPropertyValue_Rect callback_SetPropertyValue_Rect,
            Callback_SetPropertyValue_Size callback_SetPropertyValue_Size,
            Callback_SetPropertyValue_Thickness callback_SetPropertyValue_Thickness,
            Callback_SetPropertyValue_CornerRadius callback_SetPropertyValue_CornerRadius,
            Callback_SetPropertyValue_TimeSpan callback_SetPropertyValue_TimeSpan,
            Callback_SetPropertyValue_Duration callback_SetPropertyValue_Duration,
            Callback_SetPropertyValue_KeyTime callback_SetPropertyValue_KeyTime,
            Callback_SetPropertyValue_BaseComponent callback_SetPropertyValue_BaseComponent,
            Callback_CreateInstance callback_CreateInstance,
            Callback_DeleteInstance callback_DeleteInstance,
            Callback_GrabInstance callback_GrabInstance);

    }
}

