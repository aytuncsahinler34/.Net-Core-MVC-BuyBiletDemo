using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BuyBiletDemo.Core.Dto
{
    public class CommonOptionDto : BaseCommonOptionDto<int>
    {
        public CommonOptionDto(int value, string text)
            : base(value, text) {

        }
    }
    public class CommonOptionDto<TValue> : BaseCommonOptionDto<TValue>
    {
        public CommonOptionDto(TValue value, string text)
          : base(value, text) {

        }
    }
    public class CommonOptionDto<TValue, TText> : BaseCommonOptionDto<TValue, TText>
    {
        public CommonOptionDto(TValue value, TText text)
          : base(value, text) {

        }
    }
    public abstract class BaseCommonOptionDto<TValue>
    {
        public BaseCommonOptionDto(TValue value, string text) {
            this.Value = value;
            this.Text = text;
        }
        public TValue Value { get; set; }
        public string Text { get; set; }
    }

    public abstract class BaseCommonOptionDto<TValue, TText>
    {
        public BaseCommonOptionDto(TValue value, TText text) {
            this.Value = value;
            this.Text = text;
        }
        public TValue Value { get; set; }
        public TText Text { get; set; }
    }
}
