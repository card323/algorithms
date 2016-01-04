#include<iostream>

using namespace std;


void quick_sort(int a[], int start, int end)
{
    if (start >= end)
        return;
    int last_start = start;
    int last_end = end;
    while (start < end)
    {
        while (start < end && a[start] <= a[end])
            end--;

        int temp = a[start];
        a[start] = a[end];
        a[end] = temp;

        while (start < end && a[start] <= a[end])
            start++;

        temp = a[start];
        a[start] = a[end];
        a[end] = temp;
    }
    quick_sort(a, last_start, start - 1);
    quick_sort(a, start + 1, last_end);
}

void quick_sort_mid(int a[], int start, int end)
{
    if (start >= end)
        return;

    int mid = start + (end - start) / 2;
    int temp = a[start];
    a[start] = a[mid];
    a[mid] = temp;

    int last_start = start;
    int last_end = end;
    while (start < end)
    {
        while (start < end && a[start] <= a[end])
            end--;

        temp = a[start];
        a[start] = a[end];
        a[end] = temp;

        while (start < end && a[start] <= a[end])
            start++;

        temp = a[start];
        a[start] = a[end];
        a[end] = temp;
    }
    quick_sort_mid(a, last_start, start - 1);
    quick_sort_mid(a, start + 1, last_end);
}

void bubble_sort(int a[], int start, int end)
{
    bool changed = false;
    for (int i = 0; i <= end; i++)
    {
        changed = false;
        for (int j = 0; j < end - i; j++)
        {
            if (a[j]>a[j + 1])
            {
                int temp = a[j];
                a[j] = a[j + 1];
                a[j + 1] = temp;

                changed = true;
            }
        }
        if (!changed)
            break;
    }
}

void main_func(int a[], long long k, long long c[], int n)
{
    int i1 = 0;
    int r1 = 0;
    while (k > c[i1] * n)
    {
        k -= c[i1] * n;
        r1 += c[i1];
        i1++;
    }

    int i2 = 0;
    int r2 = 0;
    while (k > c[i1] * c[i2])
    {
        r2 += c[i2];
        k -= c[i1] * c[i2];
        i2++;
    }
    cout << a[r1] << " " << a[r2] << endl;
}

int main()
{
    int n;
    long long k;
    cin >> n >> k;

    int* a = new int[n];
    long long* c = new long long[n];

    for (int i = 0; i < n; i++)
    {
        cin >> a[i];
    }

    quick_sort_mid(a, 0, n - 1);

    int count = 1;
    int index = 0;
    for (int i = 1; i < n; i++)
    {
        if (a[i] == a[i - 1])
            count++;
        else
        {
            c[index++] = count;
            count = 1;
        }
    }
    c[index++] = count;
    main_func(a, k, c, n);
    return 0;
}