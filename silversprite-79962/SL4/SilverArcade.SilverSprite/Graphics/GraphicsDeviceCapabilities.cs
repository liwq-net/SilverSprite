using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Diagnostics.CodeAnalysis;

namespace Microsoft.Xna.Framework.Graphics
{
    public class GraphicsDeviceCapabilities : IDisposable
    {
        public override string  ToString()
		{
			throw new NotImplementedException();
		}

		public static bool operator ==(GraphicsDeviceCapabilities left, GraphicsDeviceCapabilities right)
		{
			throw new NotImplementedException();
		}

		public static bool operator !=(GraphicsDeviceCapabilities left, GraphicsDeviceCapabilities right)
		{
			throw new NotImplementedException();
		}

        public override int GetHashCode()
        {
            throw new NotImplementedException();
        }

        public override bool Equals(object obj)
        {
            throw new NotImplementedException();
        }

		public DeviceType DeviceType
		{
			get {throw new NotImplementedException(); }
		}
		public DriverCaps DriverCapabilities
		{
			get {throw new NotImplementedException(); }
		}
		public PresentInterval PresentInterval
		{
			get {throw new NotImplementedException(); }
		}
		public CursorCaps CursorCapabilities
		{
			get {throw new NotImplementedException(); }
		}
		public DeviceCaps DeviceCapabilities
		{
			get {throw new NotImplementedException(); }
		}
		public PrimitiveCaps PrimitiveCapabilities
		{
			get {throw new NotImplementedException(); }
		}
		public RasterCaps RasterCapabilities
		{
			get {throw new NotImplementedException(); }
		}
		public CompareCaps DepthBufferCompareCapabilities
		{
			get {throw new NotImplementedException(); }
		}
		public CompareCaps AlphaCompareCapabilities
		{
			get {throw new NotImplementedException(); }
		}
		public BlendCaps SourceBlendCapabilities
		{
			get {throw new NotImplementedException(); }
		}
		public BlendCaps DestinationBlendCapabilities
		{
			get {throw new NotImplementedException(); }
		}
		public int MaxTextureWidth
		{
			get {throw new NotImplementedException(); }
		}
		public int MaxTextureHeight
		{
			get {throw new NotImplementedException(); }
		}
		public int MaxVolumeExtent
		{
			get {throw new NotImplementedException(); }
		}
		public int MaxTextureRepeat
		{
			get {throw new NotImplementedException(); }
		}
		public int MaxTextureAspectRatio
		{
			get {throw new NotImplementedException(); }
		}
		public int MaxAnisotropy
		{
			get {throw new NotImplementedException(); }
		}
		public Single MaxVertexW
		{
			get {throw new NotImplementedException(); }
		}
		public Single GuardBandLeft
		{
			get {throw new NotImplementedException(); }
		}
		public Single GuardBandTop
		{
			get {throw new NotImplementedException(); }
		}
		public Single GuardBandRight
		{
			get {throw new NotImplementedException(); }
		}
		public Single GuardBandBottom
		{
			get {throw new NotImplementedException(); }
		}
		public Single ExtentsAdjust
		{
			get {throw new NotImplementedException(); }
		}
		public int MaxUserClipPlanes
		{
			get {throw new NotImplementedException(); }
		}
		public Single MaxPointSize
		{
			get {throw new NotImplementedException(); }
		}
		public int MaxPrimitiveCount
		{
			get {throw new NotImplementedException(); }
		}
		public int MaxVertexIndex
		{
			get {throw new NotImplementedException(); }
		}
		public int MaxStreams
		{
			get {throw new NotImplementedException(); }
		}
		public int MaxStreamStride
		{
			get {throw new NotImplementedException(); }
		}
		public Single PixelShader1xMaxValue
		{
			get {throw new NotImplementedException(); }
		}
		public int MaxSimultaneousRenderTargets
		{
			get {throw new NotImplementedException(); }
		}
		public LineCaps LineCapabilities
		{
			get {throw new NotImplementedException(); }
		}
		public ShadingCaps ShadingCapabilities
		{
			get {throw new NotImplementedException(); }
		}
		public int MaxSimultaneousTextures
		{
			get {throw new NotImplementedException(); }
		}
		public int MaxVertexShaderConstants
		{
			get {throw new NotImplementedException(); }
		}
		public int MasterAdapterOrdinal
		{
			get {throw new NotImplementedException(); }
		}
		public int AdapterOrdinalInGroup
		{
			get {throw new NotImplementedException(); }
		}
		public int NumberOfAdaptersInGroup
		{
			get {throw new NotImplementedException(); }
		}
		public TextureCaps TextureCapabilities
		{
			get {throw new NotImplementedException(); }
		}
		public FilterCaps VertexTextureFilterCapabilities
		{
			get {throw new NotImplementedException(); }
		}
		public FilterCaps TextureFilterCapabilities
		{
			get {throw new NotImplementedException(); }
		}
		public FilterCaps CubeTextureFilterCapabilities
		{
			get {throw new NotImplementedException(); }
		}
		public FilterCaps VolumeTextureFilterCapabilities
		{
			get {throw new NotImplementedException(); }
		}
		public AddressCaps TextureAddressCapabilities
		{
			get {throw new NotImplementedException(); }
		}
		public AddressCaps VolumeTextureAddressCapabilities
		{
			get {throw new NotImplementedException(); }
		}
		public StencilCaps StencilCapabilities
		{
			get {throw new NotImplementedException(); }
		}
		public VertexFormatCaps VertexFormatCapabilities
		{
			get {throw new NotImplementedException(); }
		}
		public VertexProcessingCaps VertexProcessingCapabilities
		{
			get {throw new NotImplementedException(); }
		}
		public DeclarationTypeCaps DeclarationTypeCapabilities
		{
			get {throw new NotImplementedException(); }
		}
		public Version VertexShaderVersion
		{
			get {throw new NotImplementedException(); }
		}
		public Version PixelShaderVersion
		{
			get {throw new NotImplementedException(); }
		}
		public int MaxVertexShader30InstructionSlots
		{
			get {throw new NotImplementedException(); }
		}
		public int MaxPixelShader30InstructionSlots
		{
			get {throw new NotImplementedException(); }
		}
		public VertexShaderCaps VertexShaderCapabilities
		{
			get {throw new NotImplementedException(); }
		}
		public PixelShaderCaps PixelShaderCapabilities
		{
			get {throw new NotImplementedException(); }
		}
		public ShaderProfile MaxPixelShaderProfile
		{
			get {throw new NotImplementedException(); }
		}
		public ShaderProfile MaxVertexShaderProfile
		{
			get {throw new NotImplementedException(); }
		}

		public virtual void  Dispose()
		{
			throw new NotImplementedException();
		}

        // Summary:
        //     Represents the supported blend capabilities.
        [SuppressMessage("Microsoft.Design", "CA1034:NestedTypesShouldNotBeVisible")]
        public struct BlendCaps
        {

            // Summary:
            //     Determines whether two GraphicsDeviceCapabilities.BlendCaps instances are
            //     unequal.
            //
            // Parameters:
            //   left:
            //     GraphicsDeviceCapabilities.BlendCaps on the left side of the inequality operator.
            //
            //   right:
            //     GraphicsDeviceCapabilities.BlendCaps on the right side of the inequality
            //     operator.
            //
            // Returns:
            //     true if left is not equal to right; false otherwise.
            public static bool operator !=(GraphicsDeviceCapabilities.BlendCaps left, GraphicsDeviceCapabilities.BlendCaps right)
            {
                throw new NotImplementedException();
            }
            //
            // Summary:
            //     Determines whether two GraphicsDeviceCapabilities.BlendCaps instances are
            //     equal.
            //
            // Parameters:
            //   left:
            //     GraphicsDeviceCapabilities.BlendCaps on the left side of the equal sign.
            //
            //   right:
            //     GraphicsDeviceCapabilities.BlendCaps on the right side of the equal sign.
            //
            // Returns:
            //     true if left is equal to right; false otherwise.
            public static bool operator ==(GraphicsDeviceCapabilities.BlendCaps left, GraphicsDeviceCapabilities.BlendCaps right)
            {
                throw new NotImplementedException();
            }

            // Summary:
            //     Gets a value indicating that the driver supports the Blend.BlendFactor blend
            //     mode.
            //
            // Returns:
            //     true if the driver supports the Blend.BlendFactor blend mode; false otherwise.
            public bool SupportsBlendFactor 
            {
                get { throw new NotImplementedException(); }
            }
            //
            // Summary:
            //     Gets a value indicating that the driver supports the Blend.BothInverseSourceAlpha
            //     blend mode.
            //
            // Returns:
            //     true if the driver supports the Blend.BothInverseSourceAlpha blend mode;
            //     false otherwise.
            public bool SupportsBothInverseSourceAlpha
            {
                get { throw new NotImplementedException(); }
            }
            //
            // Summary:
            //     Gets a value indicating that the driver supports the Blend.BothSourceAlpha
            //     blend mode.
            //
            // Returns:
            //     true if the driver supports the Blend.BothSourceAlpha blend mode; false otherwise.
            public bool SupportsBothSourceAlpha
            {
                get { throw new NotImplementedException(); }
            }
            //
            // Summary:
            //     Gets a value indicating that the driver supports the Blend.DestinationAlpha
            //     blend mode.
            //
            // Returns:
            //     true if the driver supports the Blend.DestinationAlpha blend mode; false
            //     otherwise.
            public bool SupportsDestinationAlpha
            {
                get { throw new NotImplementedException(); }
            }
            //
            // Summary:
            //     Gets a value indicating that the driver supports the Blend.DestinationColor
            //     blend mode.
            //
            // Returns:
            //     true if the driver supports the Blend.DestinationColor blend mode; false
            //     otherwise.
            public bool SupportsDestinationColor
            {
                get { throw new NotImplementedException(); }
            }
            //
            // Summary:
            //     Gets a value indicating that the driver supports the Blend.InverseDestinationAlpha
            //     blend mode.
            //
            // Returns:
            //     true if the driver supports the Blend.InverseDestinationAlpha blend mode;
            //     false otherwise.
            public bool SupportsInverseDestinationAlpha
            {
                get { throw new NotImplementedException(); }
            }
            //
            // Summary:
            //     Gets a value indicating that the driver supports the Blend.InverseDestinationColor
            //     blend mode.
            //
            // Returns:
            //     true if the driver supports the Blend.InverseDestinationColor blend mode;
            //     false otherwise.
            public bool SupportsInverseDestinationColor
            {
                get { throw new NotImplementedException(); }
            }
            //
            // Summary:
            //     Gets a value indicating that the driver supports the Blend.InverseSourceAlpha
            //     blend mode.
            //
            // Returns:
            //     true if the driver supports the Blend.InverseSourceAlpha blend mode; false
            //     otherwise.
            public bool SupportsInverseSourceAlpha
            {
                get { throw new NotImplementedException(); }
            }
            //
            // Summary:
            //     Gets a value indicating that the driver supports the Blend.InverseSourceColor
            //     blend mode.
            //
            // Returns:
            //     true if the driver supports the Blend.InverseSourceColor blend mode; false
            //     otherwise.
            public bool SupportsInverseSourceColor
            {
                get { throw new NotImplementedException(); }
            }
            //
            // Summary:
            //     Gets a value indicating that the driver supports the Blend.One blend mode.
            //
            // Returns:
            //     true if the driver supports the Blend.One blend mode; false otherwise.
            public bool SupportsOne
            {
                get { throw new NotImplementedException(); }
            }
            //
            // Summary:
            //     Gets a value indicating that the driver supports the Blend.SourceAlpha blend
            //     mode.
            //
            // Returns:
            //     true if the driver supports the Blend.SourceAlpha blend mode; false otherwise.
            public bool SupportsSourceAlpha
            {
                get { throw new NotImplementedException(); }
            }
            //
            // Summary:
            //     Gets a value indicating that the driver supports the Blend.SourceAlphaSat
            //     blend mode.
            //
            // Returns:
            //     true if the driver supports the Blend.SourceAlphaSat blend mode; false otherwise.
            public bool SupportsSourceAlphaSat
            {
                get { throw new NotImplementedException(); }
            }
            //
            // Summary:
            //     Gets a value indicating that the driver supports the Blend.SourceColor blend
            //     mode.
            //
            // Returns:
            //     true if the driver supports the Blend.SourceColor blend mode; false otherwise.
            public bool SupportsSourceColor
            {
                get { throw new NotImplementedException(); }
            }
            //
            // Summary:
            //     Gets a value indicating that the driver supports the Blend.Zero blend mode.
            //
            // Returns:
            //     true if the driver supports the Blend.Zero blend mode; false otherwise.
            public bool SupportsZero
            {
                get { throw new NotImplementedException(); }
            }

            // Summary:
            //     Determines whether two GraphicsDeviceCapabilities.BlendCaps instances are
            //     equal.
            //
            // Parameters:
            //   obj:
            //     The GraphicsDeviceCapabilities.BlendCaps to compare this instance to.
            //
            // Returns:
            //     true if the instances are equal; false otherwise.
            public override bool Equals(object obj) {throw new NotImplementedException(); }
            //
            // Summary:
            //     Gets the hash code for this object.
            //
            // Returns:
            //     The hash code for this object.
            public override int GetHashCode() { throw new NotImplementedException(); }
            //
            // Summary:
            //     Retrieves a string representation of this object.
            //
            // Returns:
            //     String representation of this object.
            public override string ToString() { throw new NotImplementedException(); }
        }

        // Summary:
        //     Represents comparison capabilities.
        [SuppressMessage("Microsoft.Design", "CA1034:NestedTypesShouldNotBeVisible")]
        public struct CompareCaps
        {

            // Summary:
            //     Determines whether two GraphicsDeviceCapabilities.CompareCaps instances are
            //     unequal.
            //
            // Parameters:
            //   left:
            //     GraphicsDeviceCapabilities.CompareCaps on the left side of the inequality
            //     operator.
            //
            //   right:
            //     GraphicsDeviceCapabilities.CompareCaps on the right side of the inequality
            //     operator.
            //
            // Returns:
            //     true if left is not equal to right; false otherwise.
            public static bool operator !=(GraphicsDeviceCapabilities.CompareCaps left, GraphicsDeviceCapabilities.CompareCaps right) { throw new NotImplementedException(); }
            //
            // Summary:
            //     Determines whether two GraphicsDeviceCapabilities.CompareCaps instances are
            //     equal.
            //
            // Parameters:
            //   left:
            //     GraphicsDeviceCapabilities.CompareCaps on the left side of the equal sign.
            //
            //   right:
            //     GraphicsDeviceCapabilities.CompareCaps on the right side of the equal sign.
            //
            // Returns:
            //     true if left is equal to right; false otherwise.
            public static bool operator ==(GraphicsDeviceCapabilities.CompareCaps left, GraphicsDeviceCapabilities.CompareCaps right) { throw new NotImplementedException(); }

            // Summary:
            //     Gets a value indicating whether always passing the comparison test is supported.
            //
            // Returns:
            //     true if always passing the comparison test is supported; false otherwise.
            public bool SupportsAlways
            {
                get { throw new NotImplementedException(); }
            }
            //
            // Summary:
            //     Gets a value indicating whether comparison tests in which the new value equals
            //     the current value are supported.
            //
            // Returns:
            //     true if comparison tests in which the new value equals the current value
            //     are supported; false otherwise.
            public bool SupportsEqual
            {
                get { throw new NotImplementedException(); }
            }
            //
            // Summary:
            //     Gets a value indicating whether comparison tests in which the new value is
            //     greater than the current value are supported.
            //
            // Returns:
            //     true if comparison tests in which the new value is greater than the current
            //     value are supported; false otherwise.
            public bool SupportsGreater
            {
                get { throw new NotImplementedException(); }
            }
            //
            // Summary:
            //     Gets a value indicating whether comparison tests in which the new value is
            //     greater than or equal to the current value are supported.
            //
            // Returns:
            //     true if comparison tests in which the new value is greater than or equal
            //     to the current value are supported; false otherwise.
            public bool SupportsGreaterEqual
            {
                get { throw new NotImplementedException(); }
            }
            //
            // Summary:
            //     Gets a value indicating whether comparison tests in which the new value is
            //     less than the current value are supported.
            //
            // Returns:
            //     true if comparison tests in which the new value is less than the current
            //     value are supported; false otherwise.
            public bool SupportsLess
            {
                get { throw new NotImplementedException(); }
            }
            //
            // Summary:
            //     Gets a value indicating whether comparison tests in which the new value is
            //     less than or equal to the current value are supported.
            //
            // Returns:
            //     true if comparison tests in which the new value is less than or equal to
            //     the current value are supported; false otherwise.
            public bool SupportsLessEqual
            {
                get { throw new NotImplementedException(); }
            }
            //
            // Summary:
            //     Gets a value indicating whether never passing the comparison test is supported.
            //
            // Returns:
            //     true if never passing the comparison test is supported; false otherwise.
            public bool SupportsNever
            {
                get { throw new NotImplementedException(); }
            }
            //
            // Summary:
            //     Gets a value indicating whether comparison tests in which the new value does
            //     not equal the current value are supported.
            //
            // Returns:
            //     true if comparison tests in which the new value does not equal the current
            //     value are supported; false otherwise.
            public bool SupportsNotEqual
            {
                get { throw new NotImplementedException(); }
            }

            // Summary:
            //     Determines whether two GraphicsDeviceCapabilities.CompareCaps instances are
            //     equal.
            //
            // Parameters:
            //   obj:
            //     The GraphicsDeviceCapabilities.CompareCaps object to compare this instance
            //     to.
            //
            // Returns:
            //     true if the instances are equal; false otherwise.
            public override bool Equals(object obj) { throw new NotImplementedException(); }
            //
            // Summary:
            //     Gets the hash code for this object.
            //
            // Returns:
            //     The hash code for this object.
            public override int GetHashCode() { throw new NotImplementedException(); }
            //
            // Summary:
            //     Retrieves a string representation of this object.
            //
            // Returns:
            //     String representation of this object.
            public override string ToString() { throw new NotImplementedException(); }
        }

        // Summary:
        //     Represents hardware support for cursors.
        [SuppressMessage("Microsoft.Design", "CA1034:NestedTypesShouldNotBeVisible")]
        public struct CursorCaps
        {

            // Summary:
            //     Determines whether two GraphicsDeviceCapabilities.CursorCaps instances are
            //     unequal.
            //
            // Parameters:
            //   left:
            //     GraphicsDeviceCapabilities.CursorCaps on the left side of the inequality
            //     operator.
            //
            //   right:
            //     GraphicsDeviceCapabilities.CursorCaps on the right side of the inequality
            //     operator.
            //
            // Returns:
            //     true if left is not equal to right; false otherwise.
            public static bool operator !=(GraphicsDeviceCapabilities.CursorCaps left, GraphicsDeviceCapabilities.CursorCaps right) { throw new NotImplementedException(); }
            //
            // Summary:
            //     Determines whether two GraphicsDeviceCapabilities.CursorCaps instances are
            //     equal.
            //
            // Parameters:
            //   left:
            //     GraphicsDeviceCapabilities.CursorCaps on the left side of the equal sign.
            //
            //   right:
            //     GraphicsDeviceCapabilities.CursorCaps on the right side of the equal sign.
            //
            // Returns:
            //     true if left is equal to right; false otherwise.
            public static bool operator ==(GraphicsDeviceCapabilities.CursorCaps left, GraphicsDeviceCapabilities.CursorCaps right) { throw new NotImplementedException(); }

            // Summary:
            //     Gets a value indicating whether a full-color cursor is supported in hardware
            //     in high-resolution modes.
            //
            // Returns:
            //     true if the hardware supports a full-color cursor in high resolution; false
            //     otherwise.
            public bool SupportsColor
            {
                get { throw new NotImplementedException(); }
            }
            //
            // Summary:
            //     Gets a value indicating whether a full-color cursor is supported in hardware
            //     in low-resolution modes.
            //
            // Returns:
            //     true if the hardware supports a full-color cursor in low resolution; false
            //     otherwise.
            public bool SupportsLowResolution
            {
                get { throw new NotImplementedException(); }
            }

            // Summary:
            //     Determines whether two GraphicsDeviceCapabilities.CursorCaps instances are
            //     equal.
            //
            // Parameters:
            //   obj:
            //     The GraphicsDeviceCapabilities.CursorCaps to compare this instance to.
            //
            // Returns:
            //     true if the instances are equal; false otherwise.
            public override bool Equals(object obj) { throw new NotImplementedException(); }
            //
            // Summary:
            //     Gets the hash code for this object.
            //
            // Returns:
            //     The hash code for this object.
            public override int GetHashCode() { throw new NotImplementedException(); }
            //
            // Summary:
            //     Retrieves a string representation of this object.
            //
            // Returns:
            //     String representation of this object.
            public override string ToString() { throw new NotImplementedException(); }
        }

        // Summary:
        //     Represents driver-specific capabilities.
        [SuppressMessage("Microsoft.Design", "CA1034:NestedTypesShouldNotBeVisible")]
        public struct DriverCaps
        {

            // Summary:
            //     Determines whether two GraphicsDeviceCapabilities.DriverCaps instances are
            //     unequal.
            //
            // Parameters:
            //   left:
            //     GraphicsDeviceCapabilities.DriverCaps on the left side of the inequality
            //     operator.
            //
            //   right:
            //     GraphicsDeviceCapabilities.DriverCaps on the right side of the inequality
            //     operator.
            //
            // Returns:
            //     true if left is not equal to right; false otherwise.
            public static bool operator !=(GraphicsDeviceCapabilities.DriverCaps left, GraphicsDeviceCapabilities.DriverCaps right) { throw new NotImplementedException(); }
            //
            // Summary:
            //     Determines whether two GraphicsDeviceCapabilities.DriverCaps instances are
            //     equal.
            //
            // Parameters:
            //   left:
            //     GraphicsDeviceCapabilities.DriverCaps on the left side of the equal sign.
            //
            //   right:
            //     GraphicsDeviceCapabilities.DriverCaps on the left side of the equal sign.
            //
            // Returns:
            //     true if left is equal to right; false otherwise.
            public static bool operator ==(GraphicsDeviceCapabilities.DriverCaps left, GraphicsDeviceCapabilities.DriverCaps right) { throw new NotImplementedException(); }

            // Summary:
            //     Gets a value indicating whether the driver is capable of automatically generating
            //     mipmaps.
            //
            // Returns:
            //     true if the driver is capable of automatically generating mipmaps; false
            //     otherwise.
            public bool CanAutoGenerateMipMap
            {
                get { throw new NotImplementedException(); }
            }
            //
            // Summary:
            //     Gets a value indicating whether the system has a calibrator installed that
            //     can automatically adjust the gamma ramp.
            //
            // Returns:
            //     true if the system has a calibrator installed that can automatically adjust
            //     the gamma ramp; false otherwise.
            public bool CanCalibrateGamma { get{ throw new NotImplementedException(); } }
            //
            // Summary:
            //     Gets a value indicating whether the driver is capable of managing resources.
            //
            // Returns:
            //     true if the driver is capable of managing resources; false otherwise.
            public bool CanManageResource { get{ throw new NotImplementedException(); } }
            //
            // Summary:
            //     Gets a value indicating whether the display hardware is capable of returning
            //     the current scan line.
            //
            // Returns:
            //     true if the driver display hardware is capable of returning the current scan
            //     line; false otherwise.
            public bool ReadScanLine { get{ throw new NotImplementedException(); } }
            //
            // Summary:
            //     Gets a value indicating whether the device can respect the RenderState.AlphaBlendEnable
            //     render state in full-screen mode while using the FLIP or DISCARD swap effect.
            //
            // Returns:
            //     true if the driver the device can respect the RenderState.AlphaBlendEnable
            //     render state in full-screen mode while using the FLIP or DISCARD swap effect;
            //     false otherwise.
            public bool SupportsAlphaFullScreenFlipOrDiscard { get{ throw new NotImplementedException(); } }
            //
            // Summary:
            //     Gets a value indicating whether the device can accelerate a memory copy from
            //     local video memory to system memory.
            //
            // Returns:
            //     true if the device can accelerate a memory copy from local video memory to
            //     system memory; false otherwise.
            public bool SupportsCopyToSystemMemory { get{ throw new NotImplementedException(); } }
            //
            // Summary:
            //     Gets a value indicating whether the device can accelerate a memory copy from
            //     system memory to local video memory.
            //
            // Returns:
            //     true if the device can accelerate a memory copy from system memory to local
            //     video memory; false otherwise.
            public bool SupportsCopyToVideoMemory { get{ throw new NotImplementedException(); } }
            //
            // Summary:
            //     Gets a value indicating whether the driver supports dynamic textures.
            //
            // Returns:
            //     true if the driver supports dynamic textures; false otherwise.
            public bool SupportsDynamicTextures { get{ throw new NotImplementedException(); } }
            //
            // Summary:
            //     Gets a value indicating whether the driver supports dynamic gamma ramp adjustment
            //     in full-screen mode.
            //
            // Returns:
            //     true if the driver supports dynamic gamma ramp adjustment in full-screen
            //     mode; false otherwise.
            public bool SupportsFullScreenGamma { get{ throw new NotImplementedException(); } }
            //
            // Summary:
            //     Gets a value indicating whether the device can perform gamma correction from
            //     a windowed back buffer (containing linear content) to an sRGB desktop.
            //
            // Returns:
            //     true if the device can perform gamma correction from a windowed back buffer
            //     to an sRGB desktop; false otherwise.
            public bool SupportsLinearToSrgbPresentation { get{ throw new NotImplementedException(); } }

            // Summary:
            //     Determines whether two GraphicsDeviceCapabilities.DriverCaps instances are
            //     equal.
            //
            // Parameters:
            //   obj:
            //     The GraphicsDeviceCapabilities.DriverCaps object to compare this instance
            //     to.
            //
            // Returns:
            //     true if the instances are equal; false otherwise.
            public override bool Equals(object obj) { throw new NotImplementedException(); }
            //
            // Summary:
            //     gets the hash code for this object.
            //
            // Returns:
            //     The hash code for this object.
            public override int GetHashCode() { throw new NotImplementedException(); }
            //
            // Summary:
            //     Retrieves a string representation of this object.
            //
            // Returns:
            //     String representation of this object.
            public override string ToString() { throw new NotImplementedException(); }
        }

        // Summary:
        //     Represents texture filter capabilities.
        [SuppressMessage("Microsoft.Design", "CA1034:NestedTypesShouldNotBeVisible")]
        public struct FilterCaps
        {

            // Summary:
            //     Determines whether two GraphicsDeviceCapabilities.FilterCaps instances are
            //     unequal.
            //
            // Parameters:
            //   left:
            //     GraphicsDeviceCapabilities.FilterCaps on the left side of the inequality
            //     operator.
            //
            //   right:
            //     GraphicsDeviceCapabilities.FilterCaps on the right side of the inequality
            //     operator.
            //
            // Returns:
            //     true if left is not equal to right; false otherwise.
            public static bool operator !=(GraphicsDeviceCapabilities.FilterCaps left, GraphicsDeviceCapabilities.FilterCaps right) { throw new NotImplementedException(); }
            //
            // Summary:
            //     Determines whether two GraphicsDeviceCapabilities.FilterCaps instances are
            //     equal.
            //
            // Parameters:
            //   left:
            //     GraphicsDeviceCapabilities.FilterCaps on the left side of the equal sign.
            //
            //   right:
            //     GraphicsDeviceCapabilities.FilterCaps on the right side of the equal sign.
            //
            // Returns:
            //     true if left is equal to right; false otherwise.
            public static bool operator ==(GraphicsDeviceCapabilities.FilterCaps left, GraphicsDeviceCapabilities.FilterCaps right) { throw new NotImplementedException(); }

            // Summary:
            //     Gets a value that indicates that the device supports per-stage anisotropic
            //     filtering for magnifying textures.
            //
            // Returns:
            //     true if the device supports per-stage anisotropic filtering for magnifying
            //     textures; false otherwise.
            public bool SupportsMagnifyAnisotropic { get{ throw new NotImplementedException(); } }
            //
            // Summary:
            //     Gets a value indicating whether the device supports per-stage Gaussian quad
            //     filtering for magnifying textures.
            //
            // Returns:
            //     true if the device supports per-stage Gaussian quad filtering for magnifying
            //     textures; false otherwise.
            public bool SupportsMagnifyGaussianQuad { get{ throw new NotImplementedException(); } }
            //
            // Summary:
            //     Gets a value that indicates that the device supports per-stage bilinear interpolation
            //     filtering for magnifying textures.
            //
            // Returns:
            //     true if the device supports per-stage bilinear interpolation filtering for
            //     magnifying textures; false otherwise.
            public bool SupportsMagnifyLinear { get{ throw new NotImplementedException(); } }
            //
            // Summary:
            //     Gets a value that indicates that the device supports per-stage point-sample
            //     filtering for magnifying textures.
            //
            // Returns:
            //     true if the device supports per-stage point-sample filtering for magnifying
            //     textures; false otherwise.
            public bool SupportsMagnifyPoint { get{ throw new NotImplementedException(); } }
            //
            // Summary:
            //     Gets a value that indicates that the device supports per-stage pyramidal
            //     sample filtering for magnifying textures.
            //
            // Returns:
            //     true if the device supports per-stage pyramidal sample filtering for magnifying
            //     textures; false otherwise.
            public bool SupportsMagnifyPyramidalQuad { get{ throw new NotImplementedException(); } }
            //
            // Summary:
            //     Gets a value that indicates that the device supports per-stage anisotropic
            //     filtering for minifying textures.
            //
            // Returns:
            //     true if the device supports per-stage anisotropic filtering for minifying
            //     textures; false otherwise.
            public bool SupportsMinifyAnisotropic { get{ throw new NotImplementedException(); } }
            //
            // Summary:
            //     Gets a value indicating whether the device supports per-stage Gaussian quad
            //     filtering for minifying textures.
            //
            // Returns:
            //     true if the device supports per-stage Gaussian quad filtering for magnifying
            //     textures; false otherwise.
            public bool SupportsMinifyGaussianQuad { get{ throw new NotImplementedException(); } }
            //
            // Summary:
            //     Gets a value that indicates that the device supports per-stage bilinear interpolation
            //     filtering for minifying textures.
            //
            // Returns:
            //     true if the device supports per-stage bilinear interpolation filtering for
            //     minifying textures; false otherwise.
            public bool SupportsMinifyLinear { get{ throw new NotImplementedException(); } }
            //
            // Summary:
            //     Gets a value that indicates whether the device supports per-stage point-sample
            //     filtering for minifying textures.
            //
            // Returns:
            //     true if the device supports per-stage point-sample filtering for minifying
            //     textures; false otherwise.
            public bool SupportsMinifyPoint { get{ throw new NotImplementedException(); } }
            //
            // Summary:
            //     Gets a value that indicates that the device supports per-stage pyramidal
            //     sample filtering for minifying textures.
            //
            // Returns:
            //     true if the device supports per-stage pyramidal sample filtering for minifying
            //     textures; false otherwise.
            public bool SupportsMinifyPyramidalQuad { get{ throw new NotImplementedException(); } }
            //
            // Summary:
            //     Gets a value that indicates that the device supports per-stage trilinear
            //     interpolation filtering for mipmaps.
            //
            // Returns:
            //     true if the device supports per-stage trilinear interpolation filtering for
            //     mipmaps; false otherwise.
            public bool SupportsMipMapLinear { get{ throw new NotImplementedException(); } }
            //
            // Summary:
            //     Gets a value that indicates that the device supports per-stage point-sample
            //     filtering for mipmaps.
            //
            // Returns:
            //     true if the device supports per-stage point-sample filtering for mipmaps;
            //     false otherwise.
            public bool SupportsMipMapPoint { get{ throw new NotImplementedException(); } }

            // Summary:
            //     Determines whether two GraphicsDeviceCapabilities.FilterCaps instances are
            //     equal.
            //
            // Parameters:
            //   obj:
            //     The GraphicsDeviceCapabilities.FilterCaps to compare this instance to.
            //
            // Returns:
            //     true if the instances are equal; false otherwise.
            public override bool Equals(object obj) { throw new NotImplementedException(); }
            //
            // Summary:
            //     Gets the hash code for this object.
            //
            // Returns:
            //     The hash code for this object.
            public override int GetHashCode() { throw new NotImplementedException(); }
            //
            // Summary:
            //     Retrieves a string representation of this object.
            //
            // Returns:
            //     String representation of this object.
            public override string ToString() { throw new NotImplementedException(); }
        }

        // Summary:
        //     Represents the capabilities for line-drawing primitives.
        [SuppressMessage("Microsoft.Design", "CA1034:NestedTypesShouldNotBeVisible")]
        public struct LineCaps
        {

            // Summary:
            //     Determines whether two GraphicsDeviceCapabilities.LineCaps instances are
            //     unequal.
            //
            // Parameters:
            //   left:
            //     GraphicsDeviceCapabilities.LineCaps on the left side of the inequality operator.
            //
            //   right:
            //     GraphicsDeviceCapabilities.LineCaps on the right side of the inequality operator.
            //
            // Returns:
            //     true if left is not equal to right; false otherwise.
            public static bool operator !=(GraphicsDeviceCapabilities.LineCaps left, GraphicsDeviceCapabilities.LineCaps right) { throw new NotImplementedException(); }
            //
            // Summary:
            //     Determines whether two GraphicsDeviceCapabilities.LineCaps instances are
            //     equal.
            //
            // Parameters:
            //   left:
            //     GraphicsDeviceCapabilities.LineCaps on the left side of the equal sign.
            //
            //   right:
            //     GraphicsDeviceCapabilities.LineCaps on the right side of the equal sign.
            //
            // Returns:
            //     true if left is equal to right; false otherwise.
            public static bool operator ==(GraphicsDeviceCapabilities.LineCaps left, GraphicsDeviceCapabilities.LineCaps right) { throw new NotImplementedException(); }

            // Summary:
            //     Gets a value indicating whether the device supports alpha-test comparisons.
            //
            // Returns:
            //     true if the device supports alpha-test comparisons; false otherwise.
            public bool SupportsAlphaCompare { get{ throw new NotImplementedException(); } }
            //
            // Summary:
            //     Gets a value indicating whether the device supports antialiased lines.
            //
            // Returns:
            //     true if the device supports antialiased lines; false otherwise.
            public bool SupportsAntiAlias { get{ throw new NotImplementedException(); } }
            //
            // Summary:
            //     Gets a value indicating whether the device supports source blending.
            //
            // Returns:
            //     true if the device supports source blending; false otherwise.
            public bool SupportsBlend { get{ throw new NotImplementedException(); } }
            //
            // Summary:
            //     Gets a value indicating whether the device supports depth buffer comparisons.
            //
            // Returns:
            //     true if the device supports depth buffer comparisons; false otherwise.
            public bool SupportsDepthBufferTest { get{ throw new NotImplementedException(); } }
            //
            // Summary:
            //     Gets a value indicating whether the device supports fog.
            //
            // Returns:
            //     true if the device supports fog; false otherwise.
            public bool SupportsFog { get{ throw new NotImplementedException(); } }
            //
            // Summary:
            //     Gets a value indicating whether the device supports texture mapping.
            //
            // Returns:
            //     true if the device supports texture mapping; false otherwise.
            public bool SupportsTextureMapping { get{ throw new NotImplementedException(); } }

            // Summary:
            //     Determines whether two GraphicsDeviceCapabilities.LineCaps instances are
            //     equal.
            //
            // Parameters:
            //   obj:
            //     The GraphicsDeviceCapabilities.LineCaps object to compare this instance to.
            //
            // Returns:
            //     true if the instances are equal; false otherwise.
            public override bool Equals(object obj) { throw new NotImplementedException(); }
            //
            // Summary:
            //     Gets the hash code for this object.
            //
            // Returns:
            //     The hash code for this object.
            public override int GetHashCode() { throw new NotImplementedException(); }
            //
            // Summary:
            //     Retrieves a string representation of this object.
            //
            // Returns:
            //     String representation of this object.
            public override string ToString() { throw new NotImplementedException(); }
        }

        // Summary:
        //     Represents device-specific capabilities.
        [SuppressMessage("Microsoft.Design", "CA1034:NestedTypesShouldNotBeVisible")]
        public struct DeviceCaps
        {

            // Summary:
            //     Determines whether two GraphicsDeviceCapabilities.DeviceCaps instances are
            //     unequal.
            //
            // Parameters:
            //   left:
            //     GraphicsDeviceCapabilities.DeviceCaps on the left side of the inequality
            //     operator.
            //
            //   right:
            //     GraphicsDeviceCapabilities.DeviceCaps on the right side of the inequality
            //     operator.
            //
            // Returns:
            //     true if left is not equal to right; false otherwise.
            public static bool operator !=(GraphicsDeviceCapabilities.DeviceCaps left, GraphicsDeviceCapabilities.DeviceCaps right) { throw new NotImplementedException(); }
            //
            // Summary:
            //     Determines whether two GraphicsDeviceCapabilities.DeviceCaps instances are
            //     equal.
            //
            // Parameters:
            //   left:
            //     GraphicsDeviceCapabilities.DeviceCaps on the left side of the equal sign.
            //
            //   right:
            //     GraphicsDeviceCapabilities.DeviceCaps on the right side of the equal sign.
            //
            // Returns:
            //     true if left is equal to right; false otherwise.
            public static bool operator ==(GraphicsDeviceCapabilities.DeviceCaps left, GraphicsDeviceCapabilities.DeviceCaps right) { throw new NotImplementedException(); }

            // Summary:
            //     Gets a value indicating whether the device supports blits from system-memory
            //     textures to non-local video-memory textures.
            //
            // Returns:
            //     true if the device supports blits from system-memory textures to non-local
            //     video-memory textures; false otherwise.
            public bool CanDrawSystemToNonLocal { get{ throw new NotImplementedException(); } }
            //
            // Summary:
            //     Gets a value indicating whether the device can queue rendering commands after
            //     a page flip.
            //
            // Returns:
            //     true if the device can queue rendering commands after a page flip; false
            //     otherwise.
            public bool CanRenderAfterFlip { get{ throw new NotImplementedException(); } }
            //
            // Summary:
            //     Gets a value indicating if the device supports copying the contents of a
            //     source rectangle to a destination rectangle using a texture as the source.
            //
            // Returns:
            //     true if the device supports copying the contents of a source rectangle to
            //     a destination rectangle using a texture as the source; false otherwise.
            public bool IsDirect3D9Driver { get{ throw new NotImplementedException(); } }
            //
            // Summary:
            //     Gets a value indicating whether the device can support at least a DirectX
            //     5–compliant driver.
            //
            // Returns:
            //     true if the device can support at least a DirectX 5–compliant driver; false
            //     otherwise.
            public bool SupportsDrawPrimitives2 { get{ throw new NotImplementedException(); } }
            //
            // Summary:
            //     Gets a value indicating whether the device can support at least a DirectX
            //     7–compliant driver.
            //
            // Returns:
            //     true if the device can support at least a DirectX 7–compliant driver; false
            //     otherwise.
            [SuppressMessage("Microsoft.Naming", "CA1706:ShortAcronymsShouldBeUppercase", MessageId = "Member")]
            public bool SupportsDrawPrimitives2Ex { get{ throw new NotImplementedException(); } }
            //
            // Summary:
            //     Gets a value indicating whether the device exports a GraphicsDevice.DrawPrimitives-aware
            //     hardware abstraction layer (HAL).
            //
            // Returns:
            //     true if the device exports an GraphicsDevice.DrawPrimitives-aware HAL; false
            //     otherwise.
            public bool SupportsDrawPrimitivesTransformedVertex { get{ throw new NotImplementedException(); } }
            //
            // Summary:
            //     Gets a value indicating whether the device can use execute buffers from video
            //     memory.
            //
            // Returns:
            //     true if the device can use execute buffers from video memory; false otherwise.
            public bool SupportsExecuteSystemMemory { get{ throw new NotImplementedException(); } }
            //
            // Summary:
            //     Gets a value indicating whether the device can use execute buffers from video
            //     memory.
            //
            // Returns:
            //     true if the device can use execute buffers from video memory; false otherwise.
            public bool SupportsExecuteVideoMemory { get{ throw new NotImplementedException(); } }
            //
            // Summary:
            //     Gets a value indicating whether the device has hardware acceleration for
            //     scene rasterization.
            //
            // Returns:
            //     true if the device has hardware acceleration for scene rasterization; false
            //     otherwise.
            public bool SupportsHardwareRasterization { get{ throw new NotImplementedException(); } }
            //
            // Summary:
            //     Gets a value indicating whether the device can support transformation and
            //     lighting in hardware.
            //
            // Returns:
            //     true if the device can support transformation and lighting in hardware; false
            //     otherwise.
            public bool SupportsHardwareTransformAndLight { get{ throw new NotImplementedException(); } }
            //
            // Summary:
            //     Gets a value indicating whether the device is texturing from separate memory
            //     pools.
            //
            // Returns:
            //     true if the device is texturing from separate memory pools; false otherwise.
            public bool SupportsSeparateTextureMemories { get{ throw new NotImplementedException(); } }
            //
            // Summary:
            //     Gets a value indicating whether the device supports stream offsets.
            //
            // Returns:
            //     true if the device supports stream offsets; false otherwise.
            public bool SupportsStreamOffset { get{ throw new NotImplementedException(); } }
            //
            // Summary:
            //     Gets a value indicating whether the device can retrieve textures from non-local
            //     video memory.
            //
            // Returns:
            //     true if the device can retrieve textures from non-local video memory; false
            //     otherwise.
            public bool SupportsTextureNonLocalVideoMemory { get{ throw new NotImplementedException(); } }
            //
            // Summary:
            //     Gets a value indicating whether the device can retrieve textures from system
            //     memory.
            //
            // Returns:
            //     true if the device can retrieve textures from system memory; false otherwise.
            public bool SupportsTextureSystemMemory { get{ throw new NotImplementedException(); } }
            //
            // Summary:
            //     Gets a value indicating whether the device can retrieve textures from device
            //     memory.
            //
            // Returns:
            //     true if the device can retrieve textures from device memory; false otherwise.
            public bool SupportsTextureVideoMemory { get{ throw new NotImplementedException(); } }
            //
            // Summary:
            //     Gets a value indicating whether the device can use buffers from system memory
            //     for transformed and lit vertices.
            //
            // Returns:
            //     true if the device can use buffers from system memory for transformed and
            //     lit vertices; false otherwise.
            public bool SupportsTransformedVertexSystemMemory { get{ throw new NotImplementedException(); } }
            //
            // Summary:
            //     Gets a value indicating whether the device can use buffers from video memory
            //     for transformed and lit vertices.
            //
            // Returns:
            //     true if the device can use buffers from video memory for transformed and
            //     lit vertices; false otherwise.
            public bool SupportsTransformedVertexVideoMemory { get{ throw new NotImplementedException(); } }
            //
            // Summary:
            //     Gets a value indicating whether the device allows multiple vertex elements
            //     to share the same offset in a stream.
            //
            // Returns:
            //     true if the device allows multiple vertex elements to share the same offset
            //     in a stream; false otherwise.
            public bool VertexElementScanSharesStreamOffset { get{ throw new NotImplementedException(); } }

            // Summary:
            //     Determines whether two GraphicsDeviceCapabilities.DeviceCaps instances are
            //     equal.
            //
            // Parameters:
            //   obj:
            //     The GraphicsDeviceCapabilities.DeviceCaps to compare this instance to.
            //
            // Returns:
            //     true if the instances are equal; false otherwise.
            public override bool Equals(object obj) { throw new NotImplementedException(); }
            //
            // Summary:
            //     Retrieves a string representation of this object.
            //
            // Returns:
            //     String representation of this object.
            public override string ToString() { throw new NotImplementedException(); }

            public override int GetHashCode() { throw new NotImplementedException(); }
        }

        // Summary:
        //     Represents driver primitive capabilities.
        [SuppressMessage("Microsoft.Design", "CA1034:NestedTypesShouldNotBeVisible")]
        public struct PrimitiveCaps
        {

            // Summary:
            //     Determines whether two GraphicsDeviceCapabilities.PrimitiveCaps instances
            //     are unequal.
            //
            // Parameters:
            //   left:
            //     GraphicsDeviceCapabilities.PrimitiveCaps on the left side of the inequality
            //     operator.
            //
            //   right:
            //     GraphicsDeviceCapabilities.PrimitiveCaps on the right side of the inequality
            //     operator.
            //
            // Returns:
            //     true if left is not equal to right; false otherwise.
            public static bool operator !=(GraphicsDeviceCapabilities.PrimitiveCaps left, GraphicsDeviceCapabilities.PrimitiveCaps right) { throw new NotImplementedException(); }
            //
            // Summary:
            //     Determines whether two GraphicsDeviceCapabilities.PrimitiveCaps instances
            //     are equal.
            //
            // Parameters:
            //   left:
            //     GraphicsDeviceCapabilities.PrimitiveCaps on the left side of the equal sign.
            //
            //   right:
            //     GraphicsDeviceCapabilities.PrimitiveCaps on the right side of the equal sign.
            //
            // Returns:
            //     true if left is equal to right; false otherwise.
            public static bool operator ==(GraphicsDeviceCapabilities.PrimitiveCaps left, GraphicsDeviceCapabilities.PrimitiveCaps right) { throw new NotImplementedException(); }

            // Summary:
            //     Gets a value indicating whether the device clamps fog blend factor per vertex.
            //
            // Returns:
            //     true if the device clamps fog blend factor per vertex; false otherwise.
            public bool HasFogVertexClamped { get{ throw new NotImplementedException(); } }
            //
            // Summary:
            //     Gets a value indicating whether the device is a null reference device that
            //     does not render.
            //
            // Returns:
            //     true if the device is a null reference device; false otherwise.
            public bool IsNullReference { get{ throw new NotImplementedException(); } }
            //
            // Summary:
            //     Gets a value indicating whether the device supports blending operations other
            //     than BlendFunction.Add.
            //
            // Returns:
            //     true if the driver supports other blend operations; false otherwise.
            public bool SupportsBlendOperation { get{ throw new NotImplementedException(); } }
            //
            // Summary:
            //     Gets a value indicating whether the device clips post-transformed vertex
            //     primitives.
            //
            // Returns:
            //     true if the device clips post-transformed vertex primitives; false otherwise.
            public bool SupportsClipTransformedVertices { get{ throw new NotImplementedException(); } }
            //
            // Summary:
            //     Gets a value indicating whether the device supports per-channel writes for
            //     the render-target color buffer through the RenderState.ColorWriteChannels
            //     state.
            //
            // Returns:
            //     true if the device supports per-channel writes; false otherwise.
            public bool SupportsColorWrite { get{ throw new NotImplementedException(); } }
            //
            // Summary:
            //     Gets a value indicating whether the driver supports clockwise triangle culling
            //     through the RenderState.CullMode state.
            //
            // Returns:
            //     true if the driver supports clockwise triangle culling; false otherwise.
            public bool SupportsCullClockwiseFace { get{ throw new NotImplementedException(); } }
            //
            // Summary:
            //     Gets a value indicating whether the driver supports counterclockwise triangle
            //     culling through the RenderState.CullMode state.
            //
            // Returns:
            //     true if the driver supports counterclockwise triangle culling; false otherwise.
            public bool SupportsCullCounterClockwiseFace { get{ throw new NotImplementedException(); } }
            //
            // Summary:
            //     Gets a value indicating whether the driver does not perform triangle culling.
            //
            // Returns:
            //     true if the driver does not perform triangle culling; false otherwise.
            public bool SupportsCullNone { get{ throw new NotImplementedException(); } }
            //
            // Summary:
            //     Gets a value indicating whether the driver supports separate fog and specular
            //     alpha.
            //
            // Returns:
            //     true if the driver supports separate fog and specular alpha; false otherwise.
            public bool SupportsFogAndSpecularAlpha { get{ throw new NotImplementedException(); } }
            //
            // Summary:
            //     Gets a value indicating whether the device supports independent write masks
            //     for multiple element textures or multiple render targets.
            //
            // Returns:
            //     true if the device supports independent write masks; false otherwise.
            public bool SupportsIndependentWriteMasks { get{ throw new NotImplementedException(); } }
            //
            // Summary:
            //     Gets a value indicating whether the device can enable and disable modification
            //     of the depth buffer on pixel operations.
            //
            // Returns:
            //     true if the device can enable and disable modification of the depth buffer;
            //     false otherwise.
            public bool SupportsMaskZ { get{ throw new NotImplementedException(); } }
            //
            // Summary:
            //     Gets a value indicating whether the device supports different bit depths
            //     for multiple render targets.
            //
            // Returns:
            //     true if the device supports different bit depths for multiple render targets;
            //     false otherwise.
            public bool SupportsMultipleRenderTargetsIndependentBitDepths { get{ throw new NotImplementedException(); } }
            //
            // Summary:
            //     Gets a value indicating whether the device supports post-pixel shader operations
            //     for multiple render targets.
            //
            // Returns:
            //     true if the device supports post-pixel shader operations for multiple render
            //     targets; false otherwise.
            public bool SupportsMultipleRenderTargetsPostPixelShaderBlending { get{ throw new NotImplementedException(); } }
            //
            // Summary:
            //     Gets a value indicating whether the device supports separate blend settings
            //     for the alpha channel.
            //
            // Returns:
            //     true if the device supports separate blend settings for the alpha channel;
            //     false otherwise.
            public bool SupportsSeparateAlphaBlend { get{ throw new NotImplementedException(); } }

            // Summary:
            //     Determines whether two GraphicsDeviceCapabilities.PrimitiveCaps instances
            //     are equal.
            //
            // Parameters:
            //   obj:
            //     The GraphicsDeviceCapabilities.PrimitiveCaps object to compare this instance
            //     to.
            //
            // Returns:
            //     true if the instances are equal; false otherwise.
            public override bool Equals(object obj) { throw new NotImplementedException(); }
            //
            // Summary:
            //     Gets the hash code for this object.
            //
            // Returns:
            //     The hash code for this object.
            public override int GetHashCode() { throw new NotImplementedException(); }
            //
            // Summary:
            //     Retrieves a string representation of this object.
            //
            // Returns:
            //     String representation of this object.
            public override string ToString() { throw new NotImplementedException(); }
        }

        // Summary:
        //     Represents raster-drawing capabilities.
        [SuppressMessage("Microsoft.Design", "CA1034:NestedTypesShouldNotBeVisible")]
        public struct RasterCaps
        {

            // Summary:
            //     Determines whether two GraphicsDeviceCapabilities.RasterCaps instances are
            //     unequal.
            //
            // Parameters:
            //   left:
            //     GraphicsDeviceCapabilities.RasterCaps on the left side of the inequality
            //     operator.
            //
            //   right:
            //     GraphicsDeviceCapabilities.RasterCaps on the right side of the inequality
            //     operator.
            //
            // Returns:
            //     true if left is not equal to right; false otherwise.
            public static bool operator !=(GraphicsDeviceCapabilities.RasterCaps left, GraphicsDeviceCapabilities.RasterCaps right) { throw new NotImplementedException(); }
            //
            // Summary:
            //     Determines whether two GraphicsDeviceCapabilities.RasterCaps instances are
            //     equal.
            //
            // Parameters:
            //   left:
            //     GraphicsDeviceCapabilities.RasterCaps on the left side of the equal sign.
            //
            //   right:
            //     GraphicsDeviceCapabilities.RasterCaps on the right side of the equal sign.
            //
            // Returns:
            //     true if left is equal to right; false otherwise.
            public static bool operator ==(GraphicsDeviceCapabilities.RasterCaps left, GraphicsDeviceCapabilities.RasterCaps right) { throw new NotImplementedException(); }

            // Summary:
            //     Gets a value indicating whether the device supports anisotropic filtering.
            //
            // Returns:
            //     true if the device supports anisotropic filtering; false otherwise.
            public bool SupportsAnisotropy { get{ throw new NotImplementedException(); } }
            //
            // Summary:
            //     Gets a value indicating whether the device iterates colors perspective correctly.
            //
            // Returns:
            //     true if the device iterates colors perspective correctly; false otherwise.
            public bool SupportsColorPerspective { get{ throw new NotImplementedException(); } }
            //
            // Summary:
            //     Gets a value indicating whether the device supports legacy depth bias.
            //
            // Returns:
            //     true if the device supports legacy depth bias; false otherwise.
            public bool SupportsDepthBias { get{ throw new NotImplementedException(); } }
            //
            // Summary:
            //     Gets a value indicating whether the device can perform hidden-surface removal
            //     (HSR) without requiring the application to sort polygons and without requiring
            //     the allocation of a depth buffer.
            //
            // Returns:
            //     true if the device can perform hidden-surface removal (HSR) without requiring
            //     the application to sort polygons and without requiring the allocation of
            //     a depth buffer; false otherwise.
            public bool SupportsDepthBufferLessHsr { get{ throw new NotImplementedException(); } }
            //
            // Summary:
            //     Gets a value indicating whether the device can perform depth-test operations.
            //
            // Returns:
            //     true if the device can perform depth-test operations; false otherwise.
            public bool SupportsDepthBufferTest { get{ throw new NotImplementedException(); } }
            //
            // Summary:
            //     Gets a value indicating whether the device supports depth-based fog.
            //
            // Returns:
            //     true if the device supports depth-based fog; false otherwise.
            public bool SupportsDepthFog { get{ throw new NotImplementedException(); } }
            //
            // Summary:
            //     Gets a value indicating whether the device supports range-based fog.
            //
            // Returns:
            //     true if the device supports range-based fog; false otherwise.
            public bool SupportsFogRange { get{ throw new NotImplementedException(); } }
            //
            // Summary:
            //     Gets a value indicating whether the device calculates the fog value by referring
            //     to a lookup table containing fog values that are indexed to the depth of
            //     a given pixel.
            //
            // Returns:
            //     true if the device calculates the fog value by referring to a lookup table;
            //     false otherwise.
            public bool SupportsFogTable { get{ throw new NotImplementedException(); } }
            //
            // Summary:
            //     Gets a value indicating whether the device calculates the fog value during
            //     the lighting operation and interpolates the fog value during rasterization.
            //
            // Returns:
            //     true if the device calculates the fog value during the lighting operation
            //     and interpolates the fog value during rasterization; false otherwise.
            public bool SupportsFogVertex { get{ throw new NotImplementedException(); } }
            //
            // Summary:
            //     Gets a value indicating whether the device supports level-of-detail bias
            //     adjustments.
            //
            // Returns:
            //     true if the device supports level-of-detail bias adjustments; false otherwise.
            public bool SupportsMipMapLevelOfDetailBias { get{ throw new NotImplementedException(); } }
            //
            // Summary:
            //     Gets a value indicating whether the device supports toggling multisampling
            //     on and off.
            //
            // Returns:
            //     true if the device supports toggling multisampling on and off; false otherwise.
            public bool SupportsMultisampleToggle { get{ throw new NotImplementedException(); } }
            //
            // Summary:
            //     Gets a value indicating whether the device supports scissor test.
            //
            // Returns:
            //     true if the device supports scissor test; false otherwise.
            public bool SupportsScissorTest { get{ throw new NotImplementedException(); } }
            //
            // Summary:
            //     Gets a value indicating whether the device performs true slope-scale based
            //     depth bias.
            //
            // Returns:
            //     true if the device performs true slope-scale based depth bias; false otherwise.
            public bool SupportsSlopeScaleDepthBias { get{ throw new NotImplementedException(); } }
            //
            // Summary:
            //     Gets a value indicating whether the device supports w-based fog.
            //
            // Returns:
            //     true if the device supports w-based fog; false otherwise.
            public bool SupportsWFog { get{ throw new NotImplementedException(); } }

            // Summary:
            //     Determines whether two GraphicsDeviceCapabilities.RasterCaps instances are
            //     equal.
            //
            // Parameters:
            //   obj:
            //     The GraphicsDeviceCapabilities.RasterCaps object to compare this instance
            //     to.
            //
            // Returns:
            //     true if the instances are equal; false otherwise.
            public override  bool Equals(object obj) {throw new NotImplementedException(); }
            //
            // Summary:
            //     Gets the hash code for this object.
            //
            // Returns:
            //     The hash code for this object.
            public override  int GetHashCode() {throw new NotImplementedException(); }
            //
            // Summary:
            //     Retrieves a string representation of this object.
            //
            // Returns:
            //     String representation of this object.
            public override  string ToString() {throw new NotImplementedException(); }
        }

        // Summary:
        //     Represents shading operations capabilities
        [SuppressMessage("Microsoft.Design", "CA1034:NestedTypesShouldNotBeVisible")]
        public struct ShadingCaps
        {

            // Summary:
            //     Determines whether two GraphicsDeviceCapabilities.ShadingCaps instances are
            //     unequal.
            //
            // Parameters:
            //   left:
            //     GraphicsDeviceCapabilities.ShadingCaps on the left side of the inequality
            //     operator.
            //
            //   right:
            //     GraphicsDeviceCapabilities.ShadingCaps on the right side of the inequality
            //     operator.
            //
            // Returns:
            //     true if left is not equal to right; false otherwise.
            public static bool operator !=(GraphicsDeviceCapabilities.ShadingCaps left, GraphicsDeviceCapabilities.ShadingCaps right)
            {
                throw new NotImplementedException();
            }
            //
            // Summary:
            //     Determines whether two GraphicsDeviceCapabilities.ShadingCaps instances are
            //     equal.
            //
            // Parameters:
            //   left:
            //     GraphicsDeviceCapabilities.ShadingCaps on the left side of the equal sign.
            //
            //   right:
            //     GraphicsDeviceCapabilities.ShadingCaps on the right side of the equal sign.
            //
            // Returns:
            //     true if left is equal to right; false otherwise.
            public static bool operator ==(GraphicsDeviceCapabilities.ShadingCaps left, GraphicsDeviceCapabilities.ShadingCaps right)
            {
                throw new NotImplementedException();
            }

            // Summary:
            //     Gets a value indicating whether the device can support an alpha component
            //     for Gouraud-blended transparency.
            //
            // Returns:
            //     true if can support an alpha component for Gouraud-blended transparency;
            //     false otherwise.
            public bool SupportsAlphaGouraudBlend { get{ throw new NotImplementedException(); } }
            //
            // Summary:
            //     Gets a value indicating whether the device can support colored Gouraud shading.
            //
            // Returns:
            //     true if the device can support colored Gouraud shading; false otherwise.
            public bool SupportsColorGouraudRgb { get{ throw new NotImplementedException(); } }
            //
            // Summary:
            //     Gets a value indicating whether the device can support fog in the Gouraud
            //     shading mode.
            //
            // Returns:
            //     true if the device can support fog in the Gouraud shading mode; false otherwise.
            public bool SupportsFogGouraud { get{ throw new NotImplementedException(); } }
            //
            // Summary:
            //     Gets a value indicating whether the device supports Gouraud shading of specular
            //     highlights.
            //
            // Returns:
            //     true if the device supports Gouraud shading of specular highlights; false
            //     otherwise.
            public bool SupportsSpecularGouraudRgb { get{ throw new NotImplementedException(); } }

            // Summary:
            //     Determines whether two GraphicsDeviceCapabilities.ShadingCaps instances are
            //     equal.
            //
            // Parameters:
            //   obj:
            //     The GraphicsDeviceCapabilities.ShadingCaps object to compare this instance
            //     to.
            //
            // Returns:
            //     true if the instances are equal; false otherwise.
            public override bool Equals(object obj) {throw new NotImplementedException(); }
            //
            // Summary:
            //     Gets the hash code for this object.
            //
            // Returns:
            //     The hash code for this object.
            public override int GetHashCode() {throw new NotImplementedException(); }
            //
            // Summary:
            //     Retrieves a string representation of this object.
            //
            // Returns:
            //     String representation of this object.
            public override string ToString() {throw new NotImplementedException(); }
        }

        // Summary:
        //     Represents driver stencil capabilities.
        [SuppressMessage("Microsoft.Design", "CA1034:NestedTypesShouldNotBeVisible")]
        public struct StencilCaps
        {

            // Summary:
            //     Determines whether two GraphicsDeviceCapabilities.StencilCaps instances are
            //     unequal.
            //
            // Parameters:
            //   left:
            //     GraphicsDeviceCapabilities.StencilCaps on the left side of the inequality
            //     operator.
            //
            //   right:
            //     GraphicsDeviceCapabilities.StencilCaps on the right side of the inequality
            //     operator.
            //
            // Returns:
            //     true if left is not equal to right; false otherwise.
            public static bool operator !=(GraphicsDeviceCapabilities.StencilCaps left, GraphicsDeviceCapabilities.StencilCaps right)
            {
                throw new NotImplementedException();
            }
            //
            // Summary:
            //     Determines whether two GraphicsDeviceCapabilities.StencilCaps instances are
            //     equal.
            //
            // Parameters:
            //   left:
            //     GraphicsDeviceCapabilities.StencilCaps on the left side of the equal sign.
            //
            //   right:
            //     GraphicsDeviceCapabilities.StencilCaps on the right side of the equal sign.
            //
            // Returns:
            //     true if left is equal to right; false otherwise.
            public static bool operator ==(GraphicsDeviceCapabilities.StencilCaps left, GraphicsDeviceCapabilities.StencilCaps right)
            {
                throw new NotImplementedException();
            }

            // Summary:
            //     Gets a value indicating whether the device supports decrementing the stencil-buffer
            //     entry, wrapping to the maximum value if the new value is less than zero.
            //
            // Returns:
            //     true if the device supports decrementing the stencil-buffer entry; false
            //     otherwise.
            public bool SupportsDecrement { get{ throw new NotImplementedException(); } }
            //
            // Summary:
            //     Gets a value indicating whether the device supports decrementing the stencil-buffer
            //     entry, clamping to zero.
            //
            // Returns:
            //     true if the device supports the stencil-buffer entry, clamping to zero; false
            //     otherwise.
            public bool SupportsDecrementSaturation { get{ throw new NotImplementedException(); } }
            //
            // Summary:
            //     Gets a value indicating whether the device supports incrementing the stencil-buffer
            //     entry, wrapping to zero if the new value exceeds the maximum value.
            //
            // Returns:
            //     true if the device supports incrementing the stencil-buffer entry, wrapping
            //     to zero if the new value exceeds the maximum value; false otherwise.
            public bool SupportsIncrement { get{ throw new NotImplementedException(); } }
            //
            // Summary:
            //     Gets a value indicating whether the device supports incrementing the stencil-buffer
            //     entry, clamping to the maximum value.
            //
            // Returns:
            //     true if the device supports incrementing the stencil-buffer entry, clamping
            //     to the maximum value; false otherwise.
            public bool SupportsIncrementSaturation { get{ throw new NotImplementedException(); } }
            //
            // Summary:
            //     Gets a value indicating whether the device supports inverting the bits in
            //     the stencil-buffer entry.
            //
            // Returns:
            //     true if the device supports inverting the bits in the stencil-buffer entry;
            //     false otherwise.
            public bool SupportsInvert { get{ throw new NotImplementedException(); } }
            //
            // Summary:
            //     Gets a value indicating whether the device does not update the entry in the
            //     stencil buffer.
            //
            // Returns:
            //     true if the device does not update the entry in the stencil buffer; false
            //     otherwise.
            public bool SupportsKeep { get{ throw new NotImplementedException(); } }
            //
            // Summary:
            //     Gets a value indicating whether the device supports replacing the stencil-buffer
            //     entry with a reference value.
            //
            // Returns:
            //     true if the device supports replacing the stencil-buffer entry with a reference
            //     value; false otherwise.
            public bool SupportsReplace { get{ throw new NotImplementedException(); } }
            //
            // Summary:
            //     Gets a value indicating whether the device supports two-sided stencil.
            //
            // Returns:
            //     true if the device supports two-sided stencil; false otherwise.
            public bool SupportsTwoSided { get{ throw new NotImplementedException(); } }
            //
            // Summary:
            //     Gets a value indicating whether the device supports setting the stencil-buffer
            //     entry to 0.
            //
            // Returns:
            //     true if the device supports setting the stencil-buffer entry to 0; false
            //     otherwise.
            public bool SupportsZero { get{ throw new NotImplementedException(); } }

            // Summary:
            //     Determines whether two GraphicsDeviceCapabilities.StencilCaps instances are
            //     equal.
            //
            // Parameters:
            //   obj:
            //     The GraphicsDeviceCapabilities.StencilCaps object to compare this instance
            //     to.
            //
            // Returns:
            //     true if the instances are equal; false otherwise.
            public override bool Equals(object obj) {throw new NotImplementedException(); }
            //
            // Summary:
            //     Gets the hash code for this object.
            //
            // Returns:
            //     The hash code for this object.
            public override int GetHashCode() {throw new NotImplementedException(); }
            //
            // Summary:
            //     Retrieves a string representation of this object.
            //
            // Returns:
            //     String representation of this object.
            public override string ToString() {throw new NotImplementedException(); }
        }

        // Summary:
        //     Represents miscellaneous texture-mapping capabilities
        [SuppressMessage("Microsoft.Design", "CA1034:NestedTypesShouldNotBeVisible")]
        public struct TextureCaps
        {

            // Summary:
            //     Determines whether two GraphicsDeviceCapabilities.TextureCaps instances are
            //     unequal.
            //
            // Parameters:
            //   left:
            //     GraphicsDeviceCapabilities.TextureCaps on the left side of the inequality
            //     operator.
            //
            //   right:
            //     GraphicsDeviceCapabilities.TextureCaps on the right side of the inequality
            //     operator.
            //
            // Returns:
            //     true if left is not equal to right; false otherwise.
            public static bool operator !=(GraphicsDeviceCapabilities.TextureCaps left, GraphicsDeviceCapabilities.TextureCaps right)
            {
                throw new NotImplementedException();
            }
            //
            // Summary:
            //     Determines whether two GraphicsDeviceCapabilities.TextureCaps instances are
            //     equal.
            //
            // Parameters:
            //   left:
            //     GraphicsDeviceCapabilities.TextureCaps on the left side of the equal sign.
            //
            //   right:
            //     GraphicsDeviceCapabilities.TextureCaps on the right side of the equal sign.
            //
            // Returns:
            //     true if left is equal to right; false otherwise.
            public static bool operator ==(GraphicsDeviceCapabilities.TextureCaps left, GraphicsDeviceCapabilities.TextureCaps right)
            {
                throw new NotImplementedException();
            }

            // Summary:
            //     Gets a value indicating whether the device requires that cube texture maps
            //     have dimensions specified as powers of two.
            //
            // Returns:
            //     true if the device requires that cube texture maps have dimensions specified
            //     as powers of two; false otherwise.
            public bool RequiresCubeMapPower2 { get{ throw new NotImplementedException(); } }
            //
            // Summary:
            //     Gets a value indicating whether the device only supports textures that are
            //     powers of two.
            //
            // Returns:
            //     true if the device only supports textures that are powers of two; false otherwise.
            public bool RequiresPower2 { get{ throw new NotImplementedException(); } }
            //
            // Summary:
            //     Gets a value indicating whether the device requires all textures to be square.
            //
            // Returns:
            //     true if the device requires all textures to be square; false otherwise.
            public bool RequiresSquareOnly { get{ throw new NotImplementedException(); } }
            //
            // Summary:
            //     Gets a value indicating whether the device requires that volume texture maps
            //     have dimensions specified as powers of two.
            //
            // Returns:
            //     true if the device requires that volume texture maps have dimensions specified
            //     as powers of two; false otherwise.
            public bool RequiresVolumeMapPower2 { get{ throw new NotImplementedException(); } }
            //
            // Summary:
            //     Gets a value indicating whether the device supports alpha in texture pixels.
            //
            // Returns:
            //     true if the device supports alpha in texture pixels; false otherwise.
            public bool SupportsAlpha { get{ throw new NotImplementedException(); } }
            //
            // Summary:
            //     Gets a value indicating whether the device supports cube textures
            //
            // Returns:
            //     true if the device supports cube textures; false otherwise.
            public bool SupportsCubeMap { get{ throw new NotImplementedException(); } }
            //
            // Summary:
            //     Gets a value indicating whether the device supports mipmapped cube textures.
            //
            // Returns:
            //     true if the device supports mipmapped cube textures; false otherwise.
            public bool SupportsMipCubeMap { get{ throw new NotImplementedException(); } }
            //
            // Summary:
            //     Gets a value indicating whether the device supports mipmapped textures.
            //
            // Returns:
            //     true if the device supports mipmapped textures; false otherwise.
            public bool SupportsMipMap { get{ throw new NotImplementedException(); } }
            //
            // Summary:
            //     Gets a value indicating whether the device supports mipmapped volume textures.
            //
            // Returns:
            //     true if the device supports mipmapped volume textures; false otherwise.
            public bool SupportsMipVolumeMap { get{ throw new NotImplementedException(); } }
            //
            // Summary:
            //     Gets a value indicating whether the device supports the use of 2D textures
            //     with dimensions that are not powers of two, under certain conditions.
            //
            // Returns:
            //     true if the device supports the use of 2D textures with dimensions that are
            //     not powers of two, under certain conditions; false otherwise.
            public bool SupportsNonPower2Conditional { get{ throw new NotImplementedException(); } }
            //
            // Summary:
            //     Gets a value indicating whether the device does not support a projected bump-environment
            //     lookup operation in programmable and fixed-function shaders.
            //
            // Returns:
            //     true if the device does not support a projected bump-environment lookup operation
            //     in programmable and fixed-function shaders; false otherwise.
            public bool SupportsNoProjectedBumpEnvironment { get{ throw new NotImplementedException(); } }
            //
            // Summary:
            //     Gets a value indicating whether the device supports perspective correction
            //     texturing
            //
            // Returns:
            //     true if the device supports perspective correction texturing; false otherwise.
            public bool SupportsPerspective { get{ throw new NotImplementedException(); } }
            //
            // Summary:
            //     Gets a value indicating whether the device supports per pixel projective
            //     divide.
            //
            // Returns:
            //     true if the device supports supports per pixel projective divide; false otherwise.
            public bool SupportsProjected { get{ throw new NotImplementedException(); } }
            //
            // Summary:
            //     Gets a value indicating whether the device does not scale texture indices
            //     by the texture size prior to interpolation.
            //
            // Returns:
            //     true if the device does not scale texture indices by the texture size prior
            //     to interpolation; false otherwise.
            public bool SupportsTextureRepeatNotScaledBySize { get{ throw new NotImplementedException(); } }
            //
            // Summary:
            //     Gets a value indicating whether the device supports volume textures.
            //
            // Returns:
            //     true if the device supports volume textures; false otherwise.
            public bool SupportsVolumeMap { get{ throw new NotImplementedException(); } }

            // Summary:
            //     Determines whether two GraphicsDeviceCapabilities.TextureCaps instances are
            //     equal.
            //
            // Parameters:
            //   obj:
            //     The GraphicsDeviceCapabilities.TextureCaps object to compare this instance
            //     to.
            //
            // Returns:
            //     true if the instances are equal; false otherwise.
            public override bool Equals(object obj) {throw new NotImplementedException(); }
            //
            // Summary:
            //     Gets the hash code for this object.
            //
            // Returns:
            //     The hash code for this object.
            public override int GetHashCode() {throw new NotImplementedException(); }
            //
            // Summary:
            //     Retrieves a string representation of this object.
            //
            // Returns:
            //     String representation of this object.
            public override string ToString() {throw new NotImplementedException(); }
        }

        // Summary:
        //     Represents the texture addressing capabilities for Texture structures.
        [SuppressMessage("Microsoft.Design", "CA1034:NestedTypesShouldNotBeVisible")]
        public struct AddressCaps
        {

            // Summary:
            //     Determines whether two GraphicsDeviceCapabilities.AddressCaps instances are
            //     unequal.
            //
            // Parameters:
            //   left:
            //     GraphicsDeviceCapabilities.AddressCaps on the left side of the inequality
            //     operator.
            //
            //   right:
            //     GraphicsDeviceCapabilities.AddressCaps on the right side of the inequality
            //     operator.
            //
            // Returns:
            //     true if left is not equal to right; false otherwise.
            public static bool operator !=(GraphicsDeviceCapabilities.AddressCaps left, GraphicsDeviceCapabilities.AddressCaps right)
            {
                throw new NotImplementedException();
            }
            //
            // Summary:
            //     Determines whether two GraphicsDeviceCapabilities.AddressCaps instances are
            //     equal.
            //
            // Parameters:
            //   left:
            //     GraphicsDeviceCapabilities.AddressCaps on the left side of the equal sign.
            //
            //   right:
            //     GraphicsDeviceCapabilities.AddressCaps on the right side of the equal sign.
            //
            // Returns:
            //     true if left is equal to right; false otherwise.
            public static bool operator ==(GraphicsDeviceCapabilities.AddressCaps left, GraphicsDeviceCapabilities.AddressCaps right)
            {
                throw new NotImplementedException();
            }

            // Summary:
            //     Gets a value indicating whether the device supports the setting of coordinates
            //     outside the range [0.0, 1.0] to the border color.
            //
            // Returns:
            //     true if the device supports the setting of coordinates outside the range
            //     to the border color; false otherwise.
            public bool SupportsBorder { get{ throw new NotImplementedException(); } }
            //
            // Summary:
            //     Gets a value indicating whether the device supports the clamping of textures
            //     to addresses.
            //
            // Returns:
            //     true if the device supports clamping textures to addresses; false otherwise.
            public bool SupportsClamp { get{ throw new NotImplementedException(); } }
            //
            // Summary:
            //     Gets a value indicating whether the device can separate the texture-addressing
            //     modes of the texture's u and v coordinates.
            //
            // Returns:
            //     true if the device supports separating the texture-addressing modes of the
            //     u and v coordinates; false otherwise.
            public bool SupportsIndependentUV { get{ throw new NotImplementedException(); } }
            //
            // Summary:
            //     Gets a value indicating whether a device can mirror textures to addresses.
            //
            // Returns:
            //     true if the device supports mirroring textures to addresses; false otherwise.
            public bool SupportsMirror { get{ throw new NotImplementedException(); } }
            //
            // Summary:
            //     Gets a value indicating whether a device can take the absolute value of the
            //     texture coordinate (thus, mirroring around 0) and then clamp to the maximum
            //     value.
            //
            // Returns:
            //     true if the device can mirror once; false otherwise.
            public bool SupportsMirrorOnce { get{ throw new NotImplementedException(); } }
            //
            // Summary:
            //     Gets a value indicating whether a device can wrap textures to addresses.
            //
            // Returns:
            //     true if the device can wrap textures to addresses; false otherwise.
            public bool SupportsWrap { get{ throw new NotImplementedException(); } }

            // Summary:
            //     Determines whether two GraphicsDeviceCapabilities.AddressCaps instances are
            //     equal.
            //
            // Parameters:
            //   obj:
            //     The GraphicsDeviceCapabilities.AddressCaps object this instance is being
            //     compared to .
            //
            // Returns:
            //     true if the instances are equal; false otherwise.
            public override bool Equals(object obj) {throw new NotImplementedException(); }
            //
            // Summary:
            //     Gets the hash code for this object.
            //
            // Returns:
            //     The hash code for this object.
            public override int GetHashCode() {throw new NotImplementedException(); }
            //
            // Summary:
            //     Retrieves a string representation of this object.
            //
            // Returns:
            //     String representation of this object.
            public override string ToString() {throw new NotImplementedException(); }
        }

        // Summary:
        //     Represents flexible vertex format capabilities.
        [SuppressMessage("Microsoft.Design", "CA1034:NestedTypesShouldNotBeVisible")]
        public struct VertexFormatCaps
        {

            // Summary:
            //     Determines whether two GraphicsDeviceCapabilities.VertexFormatCaps instances
            //     are unequal.
            //
            // Parameters:
            //   left:
            //     GraphicsDeviceCapabilities.VertexFormatCaps on the left side of the inequality
            //     operator.
            //
            //   right:
            //     GraphicsDeviceCapabilities.VertexFormatCaps on the right side of the inequality
            //     operator.
            //
            // Returns:
            //     true if left is not equal to right; false otherwise.
            public static bool operator !=(GraphicsDeviceCapabilities.VertexFormatCaps left, GraphicsDeviceCapabilities.VertexFormatCaps right)
            {
                throw new NotImplementedException();
            }
            //
            // Summary:
            //     Determines whether two GraphicsDeviceCapabilities.VertexFormatCaps instances
            //     are equal.
            //
            // Parameters:
            //   left:
            //     GraphicsDeviceCapabilities.VertexFormatCaps on the left side of the equal
            //     sign.
            //
            //   right:
            //     GraphicsDeviceCapabilities.VertexFormatCaps on the right side of the equal
            //     sign.
            //
            // Returns:
            //     true if left is equal to right; false otherwise.
            public static bool operator ==(GraphicsDeviceCapabilities.VertexFormatCaps left, GraphicsDeviceCapabilities.VertexFormatCaps right)
            {
                throw new NotImplementedException();
            }

            // Summary:
            //     Gets the total number of texture coordinate sets that the device can simultaneously
            //     use for multiple texture blending.
            //
            // Returns:
            //     The total number of texture coordinate sets that the device can simultaneously
            //     use for multiple texture blending. (You can use up to eight texture coordinate
            //     sets for any vertex, but the device can blend using only the specified number
            //     of texture coordinate sets.)
            public short NumberSimultaneousTextureCoordinates { get{ throw new NotImplementedException(); } }
            //
            // Summary:
            //     Gets a value indicating whether vertex elements should not be stripped.
            //
            // Returns:
            //     true if vertex elements should not be stripped; otherwise false.
            public bool SupportsDoNotStripElements { get{ throw new NotImplementedException(); } }
            //
            // Summary:
            //     Gets a value indicating whether point size comes from point size data in
            //     the vertex declaration.
            //
            // Returns:
            //     true if point size comes from point size data in the vertex declaration;
            //     otherwise false.
            public bool SupportsPointSize { get{ throw new NotImplementedException(); } }

            // Summary:
            //     Determines whether two GraphicsDeviceCapabilities.VertexFormatCaps instances
            //     are equal.
            //
            // Parameters:
            //   obj:
            //     The GraphicsDeviceCapabilities.VertexFormatCaps object to compare this instance
            //     to.
            //
            // Returns:
            //     true if the instances are equal; false otherwise.
            public override bool Equals(object obj) {throw new NotImplementedException(); }
            //
            // Summary:
            //     Gets the hash code for this object.
            //
            // Returns:
            //     The hash code for this object.
            public override int GetHashCode() {throw new NotImplementedException(); }
            //
            // Summary:
            //     Retrieves a string representation of this object.
            //
            // Returns:
            //     String representation of this object.
            public override string ToString() {throw new NotImplementedException(); }
        }

        // Summary:
        //     Represents vertex processing capabilities.
        [SuppressMessage("Microsoft.Design", "CA1034:NestedTypesShouldNotBeVisible")]
        public struct VertexProcessingCaps
        {

            // Summary:
            //     Determines whether two GraphicsDeviceCapabilities.VertexProcessingCaps instances
            //     are unequal.
            //
            // Parameters:
            //   left:
            //     GraphicsDeviceCapabilities.VertexProcessingCaps on the left side of the inequality
            //     operator.
            //
            //   right:
            //     GraphicsDeviceCapabilities.VertexProcessingCaps on the right side of the
            //     inequality operator.
            //
            // Returns:
            //     true if left is not equal to right; false otherwise.
            public static bool operator !=(GraphicsDeviceCapabilities.VertexProcessingCaps left, GraphicsDeviceCapabilities.VertexProcessingCaps right)
            {
                throw new NotImplementedException();
            }
            //
            // Summary:
            //     Determines whether two GraphicsDeviceCapabilities.VertexProcessingCaps instances
            //     are equal.
            //
            // Parameters:
            //   left:
            //     GraphicsDeviceCapabilities.VertexProcessingCaps on the left side of the equal
            //     sign.
            //
            //   right:
            //     GraphicsDeviceCapabilities.VertexProcessingCaps on the right side of the
            //     equal sign.
            //
            // Returns:
            //     true if left is equal to right; false otherwise.
            public static bool operator ==(GraphicsDeviceCapabilities.VertexProcessingCaps left, GraphicsDeviceCapabilities.VertexProcessingCaps right)
            {
                throw new NotImplementedException();
            }

            // Summary:
            //     Gets a value indicating whether the device can do local viewer.
            //
            // Returns:
            //     true if the device can do local viewer; false otherwise.
            public bool SupportsLocalViewer { get{ throw new NotImplementedException(); } }
            //
            // Summary:
            //     Gets a value indicating whether the device supports texture generation in
            //     non-local viewer mode.
            //
            // Returns:
            //     true if the device does not support texture generation in non-local viewer
            //     mode; false otherwise.
            public bool SupportsNoTextureGenerationNonLocalViewer { get{ throw new NotImplementedException(); } }
            //
            // Summary:
            //     Gets a value indicating whether the device can do texture generation.
            //
            // Returns:
            //     true if the device can do texture generation; false otherwise.
            public bool SupportsTextureGeneration { get{ throw new NotImplementedException(); } }
            //
            // Summary:
            //     Gets a value indicating whether the device supports use of the specified
            //     texture coordinates for sphere mapping.
            //
            // Returns:
            //     true if the device supports use of the specified texture coordinates for
            //     sphere mapping; false otherwise.
            public bool SupportsTextureGenerationSphereMap { get{ throw new NotImplementedException(); } }

            // Summary:
            //     Determines whether two GraphicsDeviceCapabilities.VertexProcessingCaps instances
            //     are equal.
            //
            // Parameters:
            //   obj:
            //     The GraphicsDeviceCapabilities.VertexProcessingCaps object to compare this
            //     instance to.
            //
            // Returns:
            //     true if the instances are equal; false otherwise.
            public override bool Equals(object obj) {throw new NotImplementedException(); }
            //
            // Summary:
            //     Gets the hash code for this object.
            //
            // Returns:
            //     The hash code for this object.
            public override int GetHashCode() {throw new NotImplementedException(); }
            //
            // Summary:
            //     Retrieves a string representation of this object.
            //
            // Returns:
            //     String representation of this object.
            public override string ToString() {throw new NotImplementedException(); }
        }

        // Summary:
        //     Represents vertex shader version 2_0 extended capabilities.
        [SuppressMessage("Microsoft.Design", "CA1034:NestedTypesShouldNotBeVisible")]
        public struct VertexShaderCaps
        {
            // Summary:
            //     Specifies the maximum level of nesting of dynamic flow control instructions
            //     (break - vs, break_comp - vs, breakp - vs, if_comp - vs, if_comp - vs, if
            //     pred - vs).
            public const int MaxDynamicFlowControlDepth = 24;
            //
            // Summary:
            //     Specifies the maximum number of temporary registers supported.
            public const int MaxNumberTemps = 32;
            //
            // Summary:
            //     Specifies the maximum depth of nesting of the loop - vs/rep - vs and call
            //     - vs/callnz bool - vs instructions.
            public const int MaxStaticFlowControlDepth = 4;
            //
            // Summary:
            //     Specifies the minimum level of nesting of dynamic flow control instructions
            //     (break - vs, break_comp - vs, breakp - vs, if_comp - vs, if_comp - vs, if
            //     pred - vs).
            public const int MinDynamicFlowControlDepth = 0;
            //
            // Summary:
            //     Specifies the minimum number of temporary registers supported.
            public const int MinNumberTemps = 12;
            //
            // Summary:
            //     Specifies the minimum depth of nesting of the loop - vs/rep - vs and call
            //     - vs/callnz bool - vs instructions.
            public const int MinStaticFlowControlDepth = 1;

            // Summary:
            //     Determines whether two GraphicsDeviceCapabilities.VertexShaderCaps instances
            //     are unequal.
            //
            // Parameters:
            //   left:
            //     GraphicsDeviceCapabilities.VertexShaderCaps on the left side of the inequality
            //     operator.
            //
            //   right:
            //     GraphicsDeviceCapabilities.VertexShaderCaps on the right side of the inequality
            //     operator.
            //
            // Returns:
            //     true if l is not equal to r; false otherwise.
            public static bool operator !=(GraphicsDeviceCapabilities.VertexShaderCaps left, GraphicsDeviceCapabilities.VertexShaderCaps right)
            {
                throw new NotImplementedException();
            }
            //
            // Summary:
            //     Determines whether two GraphicsDeviceCapabilities.VertexShaderCaps instances
            //     are equal.
            //
            // Parameters:
            //   left:
            //     GraphicsDeviceCapabilities.VertexShaderCaps on the left side of the equal
            //     sign.
            //
            //   right:
            //     GraphicsDeviceCapabilities.VertexShaderCaps on the right side of the equal
            //     sign.
            //
            // Returns:
            //     true if l is equal to r; false otherwise.
            public static bool operator ==(GraphicsDeviceCapabilities.VertexShaderCaps left, GraphicsDeviceCapabilities.VertexShaderCaps right)
            {
                throw new NotImplementedException();
            }

            // Summary:
            //     Gets a value specifying the depth of the dynamic flow control instruction
            //     nesting.
            //
            // Returns:
            //     The depth of the dynamic flow control instruction nesting; either 0 or 24.
            public int DynamicFlowControlDepth { get{ throw new NotImplementedException(); } }
            //
            // Summary:
            //     Gets a value specifying the number of temporary registers supported.
            //
            // Returns:
            //     The number of temporary registers supported.
            public int NumberTemps { get{ throw new NotImplementedException(); } }
            //
            // Summary:
            //     Gets a value specifying the depth of nesting of the loop - vs/rep - vs and
            //     call - vs/callnz bool - vs instructions.
            //
            // Returns:
            //     The depth of nesting of the loop - vs/rep - vs and call - vs/callnz bool
            //     - vs instructions.
            public int StaticFlowControlDepth { get{ throw new NotImplementedException(); } }
            //
            // Summary:
            //     Gets a value indicating whether instruction predication is supported.
            //
            // Returns:
            //     true if instruction predication is supported; false otherwise.
            public bool SupportsPredication { get{ throw new NotImplementedException(); } }

            // Summary:
            //     Determines whether two GraphicsDeviceCapabilities.VertexShaderCaps instances
            //     are equal.
            //
            // Parameters:
            //   obj:
            //     The GraphicsDeviceCapabilities.VertexShaderCaps object to compare this instance
            //     to.
            //
            // Returns:
            //     true if the instances are equal; false otherwise.
            public override bool Equals(object obj) {throw new NotImplementedException(); }
            //
            // Summary:
            //     Retrieves a string representation of this object.
            //
            // Returns:
            //     String representation of this object.
            public override string ToString() {throw new NotImplementedException(); }

            public override int GetHashCode() { throw new NotImplementedException(); }
        }

        // Summary:
        //     Represents pixel shader capabilities.
        [SuppressMessage("Microsoft.Design", "CA1034:NestedTypesShouldNotBeVisible")]
        public struct PixelShaderCaps
        {
            // Summary:
            //     Specifies the maximum level of nesting of dynamic flow control instructions
            //     (break - vs, break_comp - vs, breakp - vs, if_comp - vs, if_comp - vs, if
            //     pred - vs).
            public const int MaxDynamicFlowControlDepth = 24;
            //
            // Summary:
            //     Specifies the maximum number of instruction slots supported.
            public const int MaxNumberInstructionSlots = 512;
            //
            // Summary:
            //     Specifies the maximum number of temporary registers supported.
            public const int MaxNumberTemps = 32;
            //
            // Summary:
            //     Specifies the depth of nesting of the loop - vs/rep - vs and call - vs/callnz
            //     bool - vs instructions
            public const int MaxStaticFlowControlDepth = 4;
            //
            // Summary:
            //     Specifies the minimum level of nesting of dynamic flow control instructions
            //     (break - vs, break_comp - vs, breakp - vs, if_comp - vs, if_comp - vs, if
            //     pred - vs).
            public const int MinDynamicFlowControlDepth = 0;
            //
            // Summary:
            //     Specifies the minimum number of instruction slots supported.
            public const int MinNumberInstructionSlots = 96;
            //
            // Summary:
            //     Specifies the minimum number of temporary registers supported.
            public const int MinNumberTemps = 12;
            //
            // Summary:
            //     Specifies the minimum depth of nesting of the loop - vs/rep - vs and call
            //     - vs/callnz bool - vs instructions.
            public const int MinStaticFlowControlDepth = 0;

            // Summary:
            //     Determines whether two GraphicsDeviceCapabilities.PixelShaderCaps instances
            //     are unequal.
            //
            // Parameters:
            //   left:
            //     GraphicsDeviceCapabilities.PixelShaderCaps on the left side of the inequality
            //     operator.
            //
            //   right:
            //     GraphicsDeviceCapabilities.PixelShaderCaps on the right side of the inequality
            //     operator.
            //
            // Returns:
            //     true if left is not equal to right; false otherwise.
            public static bool operator !=(GraphicsDeviceCapabilities.PixelShaderCaps left, GraphicsDeviceCapabilities.PixelShaderCaps right)
            {
                throw new NotImplementedException();
            }
            //
            // Summary:
            //     Determines whether two GraphicsDeviceCapabilities.PixelShaderCaps instances
            //     are equal.
            //
            // Parameters:
            //   left:
            //     GraphicsDeviceCapabilities.PixelShaderCaps on the left side of the equal
            //     sign.
            //
            //   right:
            //     GraphicsDeviceCapabilities.PixelShaderCaps on the right side of the equal
            //     sign.
            //
            // Returns:
            //     true if left is equal to right; false otherwise.
            public static bool operator ==(GraphicsDeviceCapabilities.PixelShaderCaps left, GraphicsDeviceCapabilities.PixelShaderCaps right)
            {
                throw new NotImplementedException();
            }

            // Summary:
            //     Gets a value specifying the dynamic flow control depth.
            //
            // Returns:
            //     The dynamic flow control depth. Must be 0 or 24.
            public int DynamicFlowControlDepth { get{ throw new NotImplementedException(); } }
            //
            // Summary:
            //     Gets a value specifying the number of instruction slots supported.
            //
            // Returns:
            //     The number of instruction slots supported.
            public int NumberInstructionSlots { get{ throw new NotImplementedException(); } }
            //
            // Summary:
            //     Gets a value specifying the number of temporary registers supported.
            //
            // Returns:
            //     The number of temporary registers supported.
            public int NumberTemps { get{ throw new NotImplementedException(); } }
            //
            // Summary:
            //     Gets a value specifying the depth of nesting of the loop - vs/rep - vs and
            //     call - vs/callnz bool - vs instructions.
            //
            // Returns:
            //     The static flow control depth.
            public int StaticFlowControlDepth { get{ throw new NotImplementedException(); } }
            //
            // Summary:
            //     Gets a value indicating whether arbitrary swizzling is supported.
            //
            // Returns:
            //     true if arbitrary swizzling is supported; false otherwise.
            public bool SupportsArbitrarySwizzle { get{ throw new NotImplementedException(); } }
            //
            // Summary:
            //     Gets a value indicating whether gradient instructions are supported.
            //
            // Returns:
            //     true if gradient instructions are supported; false otherwise.
            public bool SupportsGradientInstructions { get{ throw new NotImplementedException(); } }
            //
            // Summary:
            //     Gets a value indicating whether there is a limit on the number of dependent
            //     reads per instruction.
            //
            // Returns:
            //     true if there is no dependent read limit; false otherwise.
            public bool SupportsNoDependentReadLimit { get{ throw new NotImplementedException(); } }
            //
            // Summary:
            //     Gets a value indicating whether there is a limit on the number of texture
            //     instructions.
            //
            // Returns:
            //     true if there is no limit on the number of texture instructions; false otherwise.
            public bool SupportsNoTextureInstructionLimit { get{ throw new NotImplementedException(); } }
            //
            // Summary:
            //     Gets a value indicating whether instruction predication is supported.
            //
            // Returns:
            //     true if instruction predication is supported; false otherwise.
            public bool SupportsPredication { get{ throw new NotImplementedException(); } }

            // Summary:
            //     Determines whether two GraphicsDeviceCapabilities.PixelShaderCaps instances
            //     are equal.
            //
            // Parameters:
            //   obj:
            //     The GraphicsDeviceCapabilities.PixelShaderCaps object to compare this instance
            //     to.
            //
            // Returns:
            //     true if the instances are equal; false otherwise.
            public override bool Equals(object obj) {throw new NotImplementedException(); }
            //
            // Summary:
            //     Gets the hash code for this object.
            //
            // Returns:
            //     The hash code for this object.
            public override int GetHashCode() {throw new NotImplementedException(); }
            //
            // Summary:
            //     Retrieves a string representation of this object.
            //
            // Returns:
            //     String representation of this object.
            public override string ToString() {throw new NotImplementedException(); }
        }

        // Summary:
        //     Represents data types contained in a vertex declaration.
        [SuppressMessage("Microsoft.Design", "CA1034:NestedTypesShouldNotBeVisible")]
        public struct DeclarationTypeCaps
        {

            // Summary:
            //     Determines whether two GraphicsDeviceCapabilities.DeclarationTypeCaps instances
            //     are unequal.
            //
            // Parameters:
            //   left:
            //     GraphicsDeviceCapabilities.DeclarationTypeCaps on the left side of the inequality
            //     operator.
            //
            //   right:
            //     GraphicsDeviceCapabilities.DeclarationTypeCaps on the right side of the inequality
            //     operator.
            //
            // Returns:
            //     true if left is not equal to right; false otherwise.
            public static bool operator !=(GraphicsDeviceCapabilities.DeclarationTypeCaps left, GraphicsDeviceCapabilities.DeclarationTypeCaps right)
            {
                throw new NotImplementedException();
            }
            //
            // Summary:
            //     Determines whether two GraphicsDeviceCapabilities.DeclarationTypeCaps instances
            //     are equal.
            //
            // Parameters:
            //   left:
            //     GraphicsDeviceCapabilities.DeclarationTypeCaps on the left side of the equal
            //     sign.
            //
            //   right:
            //     GraphicsDeviceCapabilities.DeclarationTypeCaps on the right side of the equal
            //     sign.
            //
            // Returns:
            //     true if left is equal to right; false otherwise.
            public static bool operator ==(GraphicsDeviceCapabilities.DeclarationTypeCaps left, GraphicsDeviceCapabilities.DeclarationTypeCaps right)
            {
                throw new NotImplementedException();
            }

            // Summary:
            //     Gets a value indicating whether vertex declarations support VertexElementFormat.Byte4.
            //
            // Returns:
            //     true if vertex declarations support VertexElementFormat.Byte4; otherwise
            //     false.
            public bool SupportsByte4 { get{ throw new NotImplementedException(); } }
            //
            // Summary:
            //     Gets a value indicating whether vertex declarations support VertexElementFormat.HalfVector2
            //
            // Returns:
            //     true if vertex declarations support VertexElementFormat.HalfVector2; otherwise
            //     false.
            public bool SupportsHalfVector2 { get{ throw new NotImplementedException(); } }
            //
            // Summary:
            //     Gets a value indicating whether vertex declarations support VertexElementFormat.HalfVector4.
            //
            // Returns:
            //     true if vertex declarations support VertexElementFormat.HalfVector4; otherwise
            //     false.
            public bool SupportsHalfVector4 { get{ throw new NotImplementedException(); } }
            //
            // Summary:
            //     Gets a value indicating whether vertex declarations support VertexElementFormat.Normalized101010.
            //
            // Returns:
            //     true if vertex declarations support VertexElementFormat.Normalized101010;
            //     otherwise false.
            public bool SupportsNormalized101010 { get{ throw new NotImplementedException(); } }
            //
            // Summary:
            //     Gets a value indicating whether vertex declarations support VertexElementFormat.NormalizedShort2.
            //
            // Returns:
            //     true if vertex declarations support VertexElementFormat.NormalizedShort2;
            //     otherwise false.
            public bool SupportsNormalizedShort2 { get{ throw new NotImplementedException(); } }
            //
            // Summary:
            //     Gets a value indicating whether vertex declarations support VertexElementFormat.NormalizedShort4.
            //
            // Returns:
            //     true if vertex declarations support VertexElementFormat.NormalizedShort4;
            //     otherwise false.
            public bool SupportsNormalizedShort4 { get{ throw new NotImplementedException(); } }
            //
            // Summary:
            //     Gets a value indicating whether vertex declarations support VertexElementFormat.Rg32.
            //
            // Returns:
            //     true if vertex declarations support VertexElementFormat.Rg32; otherwise false.
            public bool SupportsRg32 { get{ throw new NotImplementedException(); } }
            //
            // Summary:
            //     Gets a value indicating whether vertex declarations support VertexElementFormat.Rgba32.
            //
            // Returns:
            //     true if vertex declarations support VertexElementFormat.Rgba32; otherwise
            //     false.
            public bool SupportsRgba32 { get{ throw new NotImplementedException(); } }
            //
            // Summary:
            //     Gets a value indicating whether vertex declarations support VertexElementFormat.Rgba64.
            //
            // Returns:
            //     true if vertex declarations support VertexElementFormat.Rgba64; otherwise
            //     false.
            public bool SupportsRgba64 { get{ throw new NotImplementedException(); } }
            //
            // Summary:
            //     Gets a value indicating whether vertex declarations support VertexElementFormat.UInt101010.
            //
            // Returns:
            //     true if vertex declarations support VertexElementFormat.UInt101010; otherwise
            //     false.
            public bool SupportsUInt101010 { get{ throw new NotImplementedException(); } }

            // Summary:
            //     Determines whether two GraphicsDeviceCapabilities.DeclarationTypeCaps instances
            //     are equal.
            //
            // Parameters:
            //   obj:
            //     The GraphicsDeviceCapabilities.DeclarationTypeCaps object to compare this
            //     instance to.
            //
            // Returns:
            //     true if the instances are equal; false otherwise.
            public override bool Equals(object obj) {throw new NotImplementedException(); }
            //
            // Summary:
            //     Gets the hash code for this object.
            //
            // Returns:
            //     The hash code for this object.
            public override int GetHashCode() {throw new NotImplementedException(); }
            //
            // Summary:
            //     Retrieves a string representation of this object.
            //
            // Returns:
            //     String representation of this object.
            public override string ToString() {throw new NotImplementedException(); }
        }

    }
}
