using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ilwar.Giregi;

namespace 기레기_테스트
{
    class Program
    {
        static void Main(string[] args)
        {
            Generator giregi = new Generator(new Post("", "커뮤니티 일간워스트", "세부이장", "일워 기레기버튼 소스 공개", "일간워스트에서 지난주부터 서비스되고 있는 [기레기 버튼] 소스코드를 공개합니다.\n기레기 버튼은 커뮤니티글을 기사처럼 재가공해주는 스크립트버튼입니다.\nhttp://github.com/rainygirl/giregi\n\n사실 개발자분들 다 아시잖아요? 어떻게 만드는건지 ㅋㅋㅋㅋ\n그냥 문장을 \\n로 자른뒤 '라고 했다' '라면서' 라고 붙이고, 맨 뒤에 네티즌 반응을 랜덤하게 붙이면 완성.\n\n원리는 무척 간단한데,\n'그거 어떻게 만든거에요? 신기해요+.+' 하는 분들도 많아서,\n일워 코드에서 따로 빼서 공개합니다.\n\n\n\n혹시 존잘 개발자님들 계시면 Fork하셔서 뼈와 살을 덧붙여주시면 감사하겠습니다."));
            var text = giregi.Generation();
            Console.WriteLine(text);
        }
    }
}
