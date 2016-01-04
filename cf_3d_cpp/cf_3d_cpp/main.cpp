#include<cstdio>
#include<string.h>
#include<algorithm>
#include<queue>
#include<iostream>
using namespace std;
struct point{
    int val, num;
}c;
int x[50005], y[50005];
char s[50005];
bool operator <(const point &a, const point &b)
{
    return b.val<a.val;
}
priority_queue<point>q;
int main()
{
    int i = 0, cou = 0, l;
    long long res = 0;

    while (scanf("%s", s)>0)
    {
        i = 0;
        while (s[i])
        {
            if (s[i] == '?')
                scanf("%d %d", &x[i], &y[i]);
            i++;
        }
        i = cou = 0;
        l = strlen(s);
        while (i < l)
        {
            if (s[i] == '(') cou++;
            else if (s[i] == ')') cou--;
            else
            {
                c.num = i;
                c.val = x[i] - y[i];
                q.push(c);
                s[i] = ')';
                cou--;
                res += y[i];
            }
            if (cou < 0)
            {
                if (q.empty()) break;
                c = q.top();
                q.pop();
                s[c.num] = '(';
                res += c.val;
                cou = cou + 2;
            }
            i++;
        }
        if (cou == 0)
        {
            cout << res << endl;
            cout << s << endl;
        }
        else 
            cout << -1 << endl;
    }

    return  0;
}